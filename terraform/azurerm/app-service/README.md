# Example: App Service configured for Windows Container

This example provisions an App Service inside an App Service Plan which is configured to run a Windows Container.


## Set up Terraform access to Azure

Follow the guide at https://docs.microsoft.com/en-us/azure/virtual-machines/linux/terraform-install-configure

```Shell
az login
az account list --query "[].{name:name, subscriptionId:id, tenantId:tenantId}"
az account set --subscription="${SUBSCRIPTION_ID}"
az ad sp create-for-rbac --role="Contributor" --scopes="/subscriptions/${SUBSCRIPTION_ID}"
```

## Configure Terraform environment variables

```Shell
export ARM_SUBSCRIPTION_ID=your_subscription_id
export ARM_CLIENT_ID=your_appId
export ARM_CLIENT_SECRET=your_password
export ARM_TENANT_ID=your_tenant_id
```

## Run Terraform

```Shell
terraform init
terraform apply
```

## Stop and destroy 
```Shell
terrafrom destroy
```
