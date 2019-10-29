

# Azure Kubernetes Service (AKS)

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

# Not needed for public, required for usgovernment, german, china
export ARM_ENVIRONMENT=public
```

### Additional environment variables for the this project

```Shell
export TF_VAR_client_id=${ARM_CLIENT_ID}
export TF_VAR_client_secret=${ARM_CLIENT_SECRET}
export TF_VAR_admin_username=<youradminsuername>
export TF_VAR_admin_password=<youradmionpassword>
```

## Enable AKS preview features

```Shell
az extension add --name aks-preview
az feature register --name WindowsPreview --namespace Microsoft.ContainerService
az feature register -n MultiAgentpoolPreview --namespace Microsoft.ContainerService
az provider register -n Microsoft.ContainerService
```

## Run Terraform

```Shell
terraform init
terraform apply
```

## Stop and destroy 
```Shell
terrafrom destroy
````
