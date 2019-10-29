provider "azurerm" {
  version = "~>1.35"
}

#terraform {
#    backend "azurerm" {}
#}

resource "azurerm_resource_group" "k8s" {
  name     = "${var.resource_group_name}"
  location = "${var.location}"
}

resource "azurerm_kubernetes_cluster" "k8s" {
  name                = "${var.cluster_name}"
  location            = "${azurerm_resource_group.k8s.location}"
  resource_group_name = "${azurerm_resource_group.k8s.name}"
  dns_prefix          = "${var.dns_prefix}"

  network_profile {
    network_plugin = "azure"
    network_policy = "azure"
  }

  linux_profile {
    admin_username = "ubuntu"

    ssh_key {
      key_data = "${file("${var.ssh_public_key}")}"
    }
  }

  windows_profile {
    admin_username = "${var.admin_username}"
    admin_password = "${var.admin_password}"
  }

  agent_pool_profile {
    name            = "linuxpool"
    count           = 1
    vm_size         = "Standard_DS1_v2"
    os_type         = "Linux"
    os_disk_size_gb = 30
  }

  agent_pool_profile {
    name            = "windows"
    count           = 1
    vm_size         = "Standard_DS1_v2"
    type            = "VirtualMachineScaleSets"
    os_type         = "Windows"
    os_disk_size_gb = 30
    #vnet_subnet_id  = "subnet1"
  }

  service_principal {
    client_id     = "${var.client_id}"
    client_secret = "${var.client_secret}"
  }
}

output "kube_config" {
  value = "${azurerm_kubernetes_cluster.k8s.kube_config_raw}"
}

output "host" {
  value = "${azurerm_kubernetes_cluster.k8s.kube_config.0.host}"
}
