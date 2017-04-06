﻿namespace Speakr.WebApp.Site.AppStart.Configuration
{
    public class Auth0Settings
    {
        public string Domain { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string CallbackUrl { get; set; }
    }
}
