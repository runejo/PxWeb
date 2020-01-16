variable "prefix" {
  description = "The prefix used for all resources in this example"
  default     = "pxweb-code"
}

resource "azurerm_resource_group" "pxweb" {
  name     = "${var.prefix}-resources"
  location = "westeurope"
}

resource "azurerm_app_service_plan" "pxweb" {
  name                = "${var.prefix}-asp"
  location            = azurerm_resource_group.pxweb.location
  resource_group_name = azurerm_resource_group.pxweb.name

  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "pxweb" {
  name                = "${var.prefix}-appservice"
  location            = azurerm_resource_group.pxweb.location
  resource_group_name = azurerm_resource_group.pxweb.name
  app_service_plan_id = azurerm_app_service_plan.pxweb.name

  #site_config {
    #dotnet_framework_version = "v4.0"
    #scm_type                 = "LocalGit"
    #remote_debugging_enabled = true
    #remote_debugging_version = "VS2017"
  #}


}

# https://github.com/terraform-providers/terraform-provider-azurerm/issues/3696
#source_control {
#  repo_url = "https://github.com/runejo/PxWeb"
#  branch   = "master"
#}

output "website_url" {
  value = azurerm_app_service.pxweb.default_site_hostname
}