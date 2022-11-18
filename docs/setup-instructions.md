# Instructions

## Setting up ContosoTraders

1. Git clone this repository to your machine.
2. Create the `CONTOSOTRADERS_TESTING_SERVICEPRINCIPAL` github secret ([instructions here](./github-secrets.md)).
3. Next, provision the infrastructure on Azure by running the `contoso-traders-infra-provisioning` github workflow. You can do this by going to the github repo's `Actions` tab, selecting the workflow, and clicking on the `Run workflow` button.
4. Next, create the rest of the github secrets ([instructions here](./github-secrets.md)).
5. Next, deploy the apps, by running the `contoso-traders-app-deployment` workflow.

> To set up ContosoTrader in CloudLabs, you have create a fork of this github repository (one fork per lab). Then you have to repeat the same steps as above using the forked repo.

## Running ContosoTraders Locally

### Prerequisites

1. First ensure that the infrastructure setup has been completed as per steps above.
2. Ensure that you have the following installed:
   1. Node v16.18.0
   2. DOTNET 6 SDK

### Running the UI locally

1. Open a cmd window and navigate to the `src/TailwindTraders.Ui.Website` folder.
2. Run `npm install`.
3. Run `npm run start`. This will start the UI on `http://localhost:3000`.

### Running the Products API locally

TBD

### Running the Carts API locally

TBD 