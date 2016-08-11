
Param(
    [Parameter(mandatory=$true)]
    [string]
    $appName,

    [Parameter(mandatory=$true)]
    [string]
    $ec2KeyPair,

    [Parameter()]
    [string]
    $instanceType = "t2.micro",

    [Parameter()]
    [bool]
    $openRDPPort = $false,

    [Parameter()]
    [string]
    $region = "eu-west-1"
)

Import-Module AWSPowerShell

function _LaunchCloudFormationStack([string]$instanceType, [string]$keyPair, [bool]$openRDP)
{
    Write-Host "Creating CloudFormation Stack for Speakr.$appName"

    $templatePath = [System.IO.Path]::GetFullPath([System.IO.Path]::Combine($PSScriptRoot, "./cloudformation.template"))
    $templateBody = [System.IO.File]::ReadAllText($templatePath)

    $imageId = "ami-6fd5b81c"

    $param1 = New-Object  -TypeName Amazon.CloudFormation.Model.Parameter
    $param1.ParameterKey = "ImageId"
    $param1.ParameterValue = $imageId

    $param2 = New-Object  -TypeName Amazon.CloudFormation.Model.Parameter
    $param2.ParameterKey = "InstanceType"
    $param2.ParameterValue = $instanceType

    $param3 = New-Object  -TypeName Amazon.CloudFormation.Model.Parameter
    $param3.ParameterKey = "EC2KeyName"
    $param3.ParameterValue = $keyPair

    $param4 = New-Object  -TypeName Amazon.CloudFormation.Model.Parameter
    $param4.ParameterKey = "OpenRemoteDesktopPort"

    $param5 = New-Object -TypeName Amazon.CloudFormation.Model.Parameter
    $param5.ParameterKey = "AppName" 
    $param5.ParameterValue = ("speakr-{0}" -f $appName)

    if ($openRDP) 
    {
        $param4.ParameterValue = "Yes"
    }
    else 
    {
        $param4.ParameterValue = "No"
    }

    $parameters = $param1, $param2, $param3, $param4, $param5


    $stackId = New-CFNStack -StackName "speakr-$appName" -Capability "CAPABILITY_IAM" -Parameter $parameters -TemplateBody $templateBody -Region $region
    $stackId
}

function _SetupCodeDeployResources([string]$serviceRole)
{    
    _SetupCodeDeployApplication "speakr-$appName-codedeploy" $serviceRole
}


function _SetupCodeDeployApplication([string]$applicationName,[string]$serviceRole)
{
    $deploymentGroupName = ($applicationName + "-Fleet")

    $existingApplication = (Get-CDApplicationList) | Where {$_ -eq $applicationName}

    if ($existingApplication -ne $null)
    {
        ("CodeDeploy application " + $applicationName + " already existing and is being removed before recreating it")
        Remove-CDApplication -ApplicationName $applicationName -Force    
    }


    $applicationId = New-CDApplication -ApplicationName $applicationName

    $ec2Tag = New-Object -TypeName Amazon.CodeDeploy.Model.EC2TagFilter
    $ec2Tag.Key = "Name"
    $ec2Tag.Type = "KEY_AND_VALUE"
    $ec2Tag.Value = $appName

    $deploymentGroupId = New-CDDeploymentGroup -ApplicationName $applicationName -DeploymentGroupName $deploymentGroupName -Ec2TagFilter $ec2Tag -ServiceRoleArn $serviceRole

    ("CodeDeploy " + $applicationName + " application created")
}


function ProcessInput([string]$instanceType,[string]$keyPair,[bool]$openRDPPort)
{
    $stackId = _LaunchCloudFormationStack $instanceType $keyPair $openRDPPort
    $stack = Get-CFNStack -StackName $stackId -Region $region

    while ($stack.StackStatus.Value.toLower().EndsWith('in_progress'))
    {
        $stack = Get-CFNStack -StackName $stackId -Region $region
        "Waiting for CloudFormation Stack to be created"
        Start-Sleep -Seconds 10
    }

    if ($stack.StackStatus -ne "CREATE_COMPLETE") 
    {
        "CloudFormation Stack was not successfully created, view the stack events for further information on the failure"
        Exit
    }

    $serviceRoleARN = ""
    $appServerDNS = ""

    ForEach($output in $stack.Outputs)
    {
        if($output.OutputKey -eq "CodeDeployTrustRoleARN")
        {
            $serviceRoleARN = $output.OutputValue
        }
        elseif($output.OutputKey -eq "AppServerDNS")
        {
            $appServerDNS = $output.OutputValue        
        }
    }


    _SetupCodeDeployResources $serviceRoleARN
    ("CodeDeploy environment setup complete")
    ("AppServer DNS: " + $appServerDNS)
}


ProcessInput $instanceType $ec2KeyPair $openRDPPort