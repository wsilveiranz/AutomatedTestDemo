# Logic Apps Automated Test Framework Samples

This repository contains a logic apps project with a list of sample workflows associated. If you want to run this locally, you will need to follow the instructions below:

## Rehydrating Local Settings

You will find a file called dev.settings.json in the Logic Apps folder. Follow the instructions below:

1. Copy the content of *dev.settings.json* to *your local.settings.json*
2. Update the following values in dev.settings.json with valid values:
   1. "ProjectDirectoryPath": "<enter your path here>",
   2. "WORKFLOWS_TENANT_ID": "<enter your tenant id here>",
   3. "WORKFLOWS_SUBSCRIPTION_ID": "<enter your subscription id here>",    
   4. "WORKFLOWS_RESOURCE_GROUP_NAME": "<enter your resource group name here>",
   5. "WORKFLOWS_LOCATION_NAME": "<enter your location name here>",
   6. "serviceBus_connectionString": "<enter your service bus connection string here>",
   7. "commondataservice-ConnectionRuntimeUrl": "<enter your dataverse connection runtime url here
