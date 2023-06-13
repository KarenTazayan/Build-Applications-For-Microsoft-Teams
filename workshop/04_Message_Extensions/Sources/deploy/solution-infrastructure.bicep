@description('A suffix for resource names uniqueness.')
param nameSuffix string = 'd1'
param appNamePrefix string = 'sampleapp3'
param location string = resourceGroup().location

var appiName = 'appi-${appNamePrefix}-${nameSuffix}'
var planName = 'plan-${appNamePrefix}-${nameSuffix}'
var logName = 'log-${appNamePrefix}-${nameSuffix}'
var vnetName = 'vnet-${appNamePrefix}-${nameSuffix}'
var appName = 'app-${appNamePrefix}-${nameSuffix}'
var tags = {
  Purpose: 'Azure Workshop'
}

resource log 'Microsoft.OperationalInsights/workspaces@2020-08-01' = {
  name: logName
  location: location
  tags: tags
  properties: {
    sku: {
      name: 'PerGB2018'
    }
    retentionInDays: 90
  }
}

resource appi 'Microsoft.Insights/components@2020-02-02' = {
  name: appiName
  location: location
  tags: tags
  kind: 'web'
  properties: {
    Application_Type: 'web'
    DisableIpMasking: true
    publicNetworkAccessForIngestion: 'Enabled'
    publicNetworkAccessForQuery: 'Enabled'
    WorkspaceResourceId: log.id
  }
}

resource vnet 'Microsoft.Network/virtualNetworks@2021-05-01' = {
  name: vnetName
  location: location
  tags: tags
  properties: {
    addressSpace: {
      addressPrefixes: [
        '10.0.0.0/16'
      ]
    }
    subnets: [
      {
        name: 'AppHost'
        properties: {
          addressPrefix: '10.0.0.0/24'
          delegations: [
            {
              name: 'delegation'
              properties: {
                serviceName: 'Microsoft.Web/serverFarms'
              }
            }
          ]
        }
      }
    ]
  }
}

resource planShoppingAppUi 'Microsoft.Web/serverfarms@2021-03-01' = {
  name: planName
  location: location
  tags: tags
  kind: 'app'
  sku: {
    name: 'B1'
  }
}

resource app 'Microsoft.Web/sites@2021-03-01' = {
  name: appName
  location: location
  tags: tags
  kind: 'app'
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    serverFarmId: planShoppingAppUi.id
    virtualNetworkSubnetId: vnet.properties.subnets[0].id
    siteConfig: {
      alwaysOn: true
      webSocketsEnabled: true
      netFrameworkVersion: 'v7.0'
    }
  }
}

resource appConfig1 'Microsoft.Web/sites/config@2021-03-01' = {
  parent: app
  name: 'metadata'
  properties: {
    CURRENT_STACK: 'dotnet'
  }
}

resource appConfig2 'Microsoft.Web/sites/config@2021-03-01' = {
  parent: app
  name: 'appsettings'
  properties: {
    APPINSIGHTS_CONNECTION_STRING: appi.properties.ConnectionString
    BaseUrl: 'https://${app.properties.hostNames[0]}'
    MicrosoftAppId: 'xxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
    MicrosoftAppPassword: 'xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx'
  }
}

resource botService 'Microsoft.BotService/botServices@2022-09-15' = {
  name: 'bot-${appNamePrefix}-${nameSuffix}'
  location: 'global'
  tags: tags
  sku: {
    name: 'S1'
  }
  kind: 'azurebot'
  properties: {
    displayName: 'bot-${appNamePrefix}-${nameSuffix}'
    endpoint: 'https://${app.properties.hostNames[0]}/api/messages'
    msaAppId: 'xxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx'
    msaAppType: 'MultiTenant'
  }
}

output fullReferenceOutput object = app.properties
