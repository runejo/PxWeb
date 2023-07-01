[![MSBuild](https://github.com/runejo/PxWeb/actions/workflows/msbuild.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/msbuild.yml)
[![Docker Image CI](https://github.com/runejo/PxWeb/actions/workflows/dockerimage.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/dockerimage.yml)
[![CodeQL](https://github.com/runejo/PxWeb/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/codeql-analysis.yml)
[![Build Status](https://travis-ci.org/runejo/PxWeb.svg?branch=master)](https://travis-ci.org/runejo/PxWeb)
[![Maintainability](https://api.codeclimate.com/v1/badges/d46673e9ae35d2a6bdd6/maintainability)](https://codeclimate.com/github/runejo/PxWeb/maintainability)
[![Mentioned in Awesome Official Statistics ](https://awesome.re/mentioned-badge.svg)](http://www.awesomeofficialstatistics.org)
# PxWeb
This is the official source code repository for PxWeb. PxWeb is a nice web application for dissemination of statistical tables please read more abou it at the official web page on Statistics Sweden web site at [www.scb.se/px-web](https://www.scb.se/px-web).

## Current activities
We are currently working on a version 2 of the API. Read more about it at [https://www.scb.se/en/services/open-data-api/pxapi-2.0/](https://www.scb.se/en/services/open-data-api/pxapi-2.0/). The development is done in the pxapi2/master branch of this repository.

## Installation
The compiled version is available free of charge for governmental agencies and municipalities, international NSI:s an international organisations of statistics. Please read the terms of use at this page [https://www.scb.se/pxweb](https://www.scb.se/pxweb). 

If you like to get access to the compiled version of the source, ready to install in your environment, please send a mail to [px@scb.se](mailto:px@scb.se?subject=Access%20to%20download%20portal) and you will receive credentials to Statistics Sweden’s download portal where you can download a complied version together with instructions.

## Test with Docker
Create a Docker image and run it for easy testing

> **_NOTE:_**  Images require [Docker Desktop](https://www.docker.com/products/docker-desktop) running on a Windows host with hardware virtualization enabled in BIOS settings

```
docker build -t pxweb .
docker run -p 80:80 pxweb
```
## Test with Azure App Service

* [Terraform App Service with Docker](terraform/azurerm/app-service)
* [Terraform App Service with GitHub](terraform/azurerm/app-service-code)

## Test with Azure Kubernetes Service (AKS) 

* [Terraform AKS](terraform/azurerm/kubernetes) (work in progress)
The compiled version is available free of charge for governmental agencies and municipalities, international NSI:s an international organisations of statistics. Please read the terms of use at this page [https://www.scb.se/pxweb](https://www.scb.se/pxweb). 
