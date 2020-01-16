variable "prefix" {
  description = "The prefix used for all resources in this example"
  default     = "pxweb-docker"
}

resource "azurerm_resource_group" "example" {
  name     = "${var.prefix}-resources"
  location = "westeurope"
}

resource "azurerm_app_service_plan" "example" {
  name                = "${var.prefix}-asp"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  kind                = "xenon"
  is_xenon            = true

  sku {
    tier = "PremiumContainer"
    size = "PC2"
  }
}

resource "azurerm_app_service" "example" {
  name                = "${var.prefix}-appservice"
  location            = azurerm_resource_group.example.location
  resource_group_name = azurerm_resource_group.example.name
  app_service_plan_id = azurerm_app_service_plan.example.name

  site_config {
    windows_fx_version = "DOCKER|runejo/pxweb:windowsservercore-1803"
  }

  app_settings = {
    "DOCKER_REGISTRY_SERVER_URL" = "https://index.docker.io",
  }
}

output "website_url" {
  value = azurerm_app_service.example.default_site_hostname
}