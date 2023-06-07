## Build Applications for Microsoft Teams

### 1. Required resources and tools

 * Make sure you have an active Azure subscription. You [can create](https://azure.microsoft.com/en-us/free/) it free.
 * [Microsoft 365 Developer Program Accaunt](https://learn.microsoft.com/en-us/office/developer-program/microsoft-365-developer-program-get-started)
 * Install [Visual Studio](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2022) or [Visual Studio Code](https://code.visualstudio.com/download) to run and debug the sample code.
  * [.NET Core SDK](https://dotnet.microsoft.com/download) version 6.0
* Install [ngrok](https://ngrok.com/download) for local setup. (or any other tunneling solution)

### 2. Create an Azure DevOps project for the solution.

1. Open Azure DevOps portal : https://dev.azure.com/
2. Create new organization/use an existing organization.
3. Create a new public project. A sample name: **Build-Applications-For-Microsoft-Teams**. For a public project Microsoft provides 
[unlimited restriction for parallel jobs](https://learn.microsoft.com/en-us/azure/devops/pipelines/licensing/concurrent-jobs) (by default up to 25 parallel jobs) in case you use self-hosted agents.  
1. Import existing repository: https://github.com/KarenTazayan/Build-Applications-For-Microsoft-Teams
2. Create YAML pipeline by using exsisting "Azure-Pipelines.yml" from imporeted sources. A sample name: **Default CI and CD** pipeline. After creation just only save it, don't run it.

### 3. Create a service connection for the Azure DevOps project.

Use your existing Microsoft Azure Subscription, [you can create a free account](https://azure.microsoft.com/en-us/free/) if you don't have any.  
By using Azure CLI create a service principal and configure its access to Azure resources. To retrieve current subscription ID, run:  
```
az account show --query id --output tsv
```
Configure its access to Azure subscription:
```
az ad sp create-for-rbac --name Build-Applications-For-Microsoft-Teams --role Owner --scopes /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx