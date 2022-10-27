// common
targetScope = 'resourceGroup'

// parameters
////////////////////////////////////////////////////////////////////////////////

// common
param resourceLocation string = resourceGroup().location

param suffix string = '8644'

// variables
////////////////////////////////////////////////////////////////////////////////

// cosmos db (stocks db)
var stocksDbAcctName = 'tailwind-traders-stocks'
var stocksDbName = 'stocksdb'
var stocksDbStocksContainerName = 'stocks'

// sql azure (products db)
var productsDbServerName = 'tailwind-traders-products'
var productsDbName = 'productsdb'
var productsDbServerAdminLogin = 'localadmin'
var productsDbServerAdminPassword = 'Password123!'

// app service plan (products api)
var productsApiAppSvcPlanName = 'tailwind-traders-products'

// tags
var resourceTags = {
  Product: 'tailwind-traders'
  Environment: 'testing'
}

// resources
////////////////////////////////////////////////////////////////////////////////

//
// stocks db
//

// cosmos db account
resource stocksdba 'Microsoft.DocumentDB/databaseAccounts@2022-02-15-preview' = {
  name: '${stocksDbAcctName}${suffix}'
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
  name: '${productsDbServerName}${suffix}'
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
resource symbolicname 'Microsoft.Web/serverfarms@2022-03-01' = {
  name: '${productsApiAppSvcPlanName}${suffix}'
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

// outputs
////////////////////////////////////////////////////////////////////////////////
