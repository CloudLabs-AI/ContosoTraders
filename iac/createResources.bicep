// common
targetScope = 'resourceGroup'

// parameters
////////////////////////////////////////////////////////////////////////////////

// common
param resourceLocation string = resourceGroup().location
param suffix string = '8644'

// tenant
param tenantId string = '6d7e0652-b03d-4ed2-bf86-f1999cecde17'

// variables
////////////////////////////////////////////////////////////////////////////////

// key vault
var keyVaultName = 'tailwind-traders-kv${suffix}'

// cosmos db (stocks db)
var stocksDbAcctName = 'tailwind-traders-stocks${suffix}'
var stocksDbName = 'stocksdb'
var stocksDbStocksContainerName = 'stocks'

// sql azure (products db)
var productsDbServerName = 'tailwind-traders-products${suffix}'
var productsDbName = 'productsdb'
var productsDbServerAdminLogin = 'localadmin'
var productsDbServerAdminPassword = 'Password123!'

// app service plan (products api)
var productsApiAppSvcPlanName = 'tailwind-traders-products${suffix}'
var productsApiAppSvcName = 'tailwind-traders-products${suffix}'

// tags
var resourceTags = {
  Product: 'tailwind-traders'
  Environment: 'testing'
}

// resources
////////////////////////////////////////////////////////////////////////////////

//
// key vault
//

resource symbolicname 'Microsoft.KeyVault/vaults@2022-07-01' = {
  name: keyVaultName
  location: resourceLocation
  tags: resourceTags
  properties: {
    sku: {
      family: 'A'
      name: 'standard'
    }
    accessPolicies: [
    ]
    softDeleteRetentionInDays: 7
    tenantId: tenantId
  }
}

//
// stocks db
//

// cosmos db account
resource stocksdba 'Microsoft.DocumentDB/databaseAccounts@2022-02-15-preview' = {
  name: stocksDbAcctName
  location: resourceLocation
  tags: resourceTags
  properties: {
    databaseAccountOfferType: 'Standard'
    enableFreeTier: false
    capabilities: [
      {
        name: 'EnableServerless'
      }
    ]
    locations: [
      {
        locationName: resourceLocation
      }
    ]
  }

  // cosmos db database
  resource stocksdba_db 'sqlDatabases' = {
    name: stocksDbName
    location: resourceLocation
    tags: resourceTags
    properties: {
      resource: {
        id: stocksDbName
      }
    }

    // cosmos db collection
    resource stocksdba_db_c1 'containers' = {
      name: stocksDbStocksContainerName
      location: resourceLocation
      tags: resourceTags
      properties: {
        resource: {
          id: stocksDbStocksContainerName
          partitionKey: {
            paths: [
              '/id'
            ]
          }
        }
      }
    }

  }
}

//
// products db
//

// sql azure server
resource productsdbsrv 'Microsoft.Sql/servers@2022-05-01-preview' = {
  name: productsDbServerName
  location: resourceLocation
  tags: resourceTags
  properties: {
    administratorLogin: productsDbServerAdminLogin
    administratorLoginPassword: productsDbServerAdminPassword
    publicNetworkAccess: 'Enabled'
  }

  // sql azure database
  resource productsdbsrv_db 'databases' = {
    name: productsDbName
    location: resourceLocation
    tags: resourceTags
    sku: {
      capacity: 5
      tier: 'Basic'
      name: 'Basic'
    }
  }

  // sql azure firewall rule (allow access from all azure resources/services)
  resource productsdbsrv_db_fwl 'firewallRules' = {
    name: 'AllowAllWindowsAzureIps'
    properties: {
      endIpAddress: '0.0.0.0'
      startIpAddress: '0.0.0.0'
    }
  }

}

//
// products api
//

// app service plan (linux)
resource productsapiappsvcplan 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: productsApiAppSvcPlanName
  location: resourceLocation
  tags: resourceTags
  sku: {
    name: 'B1'
  }
  properties: {
    reserved: true
  }
  kind: 'linux'
}

// app service
resource productsapiappsvc 'Microsoft.Web/sites@2022-03-01' = {
  name: productsApiAppSvcName
  location: resourceLocation
  tags: resourceTags
  identity: {
    type: 'SystemAssigned'
  }
  properties: {
    clientAffinityEnabled: false
    httpsOnly: true
    serverFarmId: productsapiappsvcplan.id
    siteConfig: {
      linuxFxVersion: 'DOTNETCORE|6.0'
      alwaysOn: true
    }
  }
}

// outputs
////////////////////////////////////////////////////////////////////////////////
