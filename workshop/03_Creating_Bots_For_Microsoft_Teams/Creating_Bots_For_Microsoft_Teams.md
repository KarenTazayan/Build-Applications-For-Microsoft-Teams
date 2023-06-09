## Creating Bots For Microsoft Teams

Create an Azure AD application:
```
az ad app create --display-name SampleApp2Bot --sign-in-audience AzureADMultipleOrgs `
    --key-display-name Default --key-type Password
```
For local running and debugging.
```
ngrok http 3978 --host-header="localhost:3978"
```

For more information [please go here](https://learn.microsoft.com/en-us/microsoftteams/platform/bots/what-are-bots).