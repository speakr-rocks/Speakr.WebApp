﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Speakr.WebApp.Site.AppStart;
using Speakr.WebApp.Site.AppStart.Configuration;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Speakr.WebApp.AppStart
{
    public class Startup
    {
        public IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = AppConfiguration.Configure(env);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            IoCRegistry.RegisterDependencies(services, Configuration);

            services.AddAuthentication(options => options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme);

            services.AddMvc();

            services.AddOptions();

            // Add the Auth0 Settings object so it can be injected
            services.Configure<Auth0Settings>(Configuration.GetSection("Auth0Settings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IOptions<Auth0Settings> auth0Settings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            // Add the cookie middleware
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true
            });

            // Add the OIDC middleware
            var options = new OpenIdConnectOptions("Auth0")
            {
                // Set the authority to your Auth0 domain
                Authority = $"https://{auth0Settings.Value.Domain}",

                // Configure the Auth0 Client ID and Client Secret
                ClientId = auth0Settings.Value.ClientId,
                ClientSecret = auth0Settings.Value.ClientSecret,

                // Do not automatically authenticate and challenge
                AutomaticAuthenticate = false,
                AutomaticChallenge = false,

                // Set response type to code
                ResponseType = "code",

                // Set the callback path, so Auth0 will call back to http://localhost:5000/signin-auth0 
                // Also ensure that you have added the URL as an Allowed Callback URL in your Auth0 dashboard 
                CallbackPath = new PathString("/signin-auth0"),

                // Configure the Claims Issuer to be Auth0
                ClaimsIssuer = "Auth0",

                // Saves tokens to the AuthenticationProperties
                SaveTokens = true,

                Events = new OpenIdConnectEvents
                {
                    // handle the logout redirection 
                    OnRedirectToIdentityProviderForSignOut = (context) =>
                    {
                        var logoutUri = $"https://{auth0Settings.Value.Domain}/v2/logout?client_id={auth0Settings.Value.ClientId}";

                        var postLogoutUri = context.Properties.RedirectUri;
                        if (!string.IsNullOrEmpty(postLogoutUri))
                        {
                            if (postLogoutUri.StartsWith("/"))
                            {
                                // transform to absolute
                                var request = context.Request;
                                postLogoutUri = request.Scheme + "://" + request.Host + request.PathBase + postLogoutUri;
                            }
                            logoutUri += $"&returnTo={ Uri.EscapeDataString(postLogoutUri)}";
                        }

                        context.Response.Redirect(logoutUri);
                        context.HandleResponse();

                        return Task.CompletedTask;
                    },

                    OnTicketReceived = context =>
                    {
                        // Get the ClaimsIdentity
                        var identity = context.Principal.Identity as ClaimsIdentity;
                        if (identity != null)
                        {
                            // Add the Name ClaimType. This is required if we want User.Identity.Name to actually return something!
                            if (!context.Principal.HasClaim(c => c.Type == ClaimTypes.Name) &&
                                identity.HasClaim(c => c.Type == "name"))
                                identity.AddClaim(new Claim(ClaimTypes.Name, identity.FindFirst("name").Value));

                            // Check if token names are stored in Properties
                            if (context.Properties.Items.ContainsKey(".TokenNames"))
                            {
                                // Token names a semicolon separated
                                string[] tokenNames = context.Properties.Items[".TokenNames"].Split(';');

                                // Add each token value as Claim
                                foreach (var tokenName in tokenNames)
                                {
                                    // Tokens are stored in a Dictionary with the Key ".Token.<token name>"
                                    string tokenValue = context.Properties.Items[$".Token.{tokenName}"];

                                    identity.AddClaim(new Claim(tokenName, tokenValue));
                                }
                            }
                        }

                        return Task.CompletedTask;
                    },
                }
            };
            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("name");
            options.Scope.Add("email");
            options.Scope.Add("picture");
            options.Scope.Add("country");
            options.Scope.Add("roles");
            app.UseOpenIdConnectAuthentication(options);


            app.UseMvc();
        }
    }
}
