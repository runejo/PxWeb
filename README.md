[![Build Status](https://travis-ci.org/runejo/PxWeb.svg?branch=master)](https://travis-ci.org/runejo/PxWeb)
[![Maintainability](https://api.codeclimate.com/v1/badges/d46673e9ae35d2a6bdd6/maintainability)](https://codeclimate.com/github/runejo/PxWeb/maintainability)

# PxWeb
This repository currently only contains the source code for PxWeb 2019 v1.
The next step is to add/move all the fixes in this version from our other repository to this one as soon as possible and there by making this repository the official PxWeb repository.

## Test with Docker
Create a Docker image and run it for easy testing

> **_NOTE:_**  Images require Docker running on a Windows host with hardware virtualization enabled in BIOS settings

```
docker build -t pxweb .
docker run -p 80:80 pxweb
```
## Test with Azure App Service

* [Terraform App Service with Docker](terraform/azurerm/app-service)
* [Terraform App Service with GitHub](terraform/azurerm/app-service-code)

## Test with Azure Kubernetes Service (AKS) 

* [Terraform AKS](terraform/azurerm/kubernetes) (work in progress)
