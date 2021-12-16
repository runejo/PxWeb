[![MSBuild](https://github.com/runejo/PxWeb/actions/workflows/msbuild.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/msbuild.yml)
[![Docker Image CI](https://github.com/runejo/PxWeb/actions/workflows/dockerimage.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/dockerimage.yml)
[![CodeQL](https://github.com/runejo/PxWeb/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/runejo/PxWeb/actions/workflows/codeql-analysis.yml)
[![Build Status](https://travis-ci.org/runejo/PxWeb.svg?branch=master)](https://travis-ci.org/runejo/PxWeb)
[![Maintainability](https://api.codeclimate.com/v1/badges/d46673e9ae35d2a6bdd6/maintainability)](https://codeclimate.com/github/runejo/PxWeb/maintainability)
[![Mentioned in Awesome Official Statistics ](https://awesome.re/mentioned-badge.svg)](http://www.awesomeofficialstatistics.org)
# PxWeb
This is the official source code repository for PxWeb. PxWeb is a nice web application for dissemination of statistical tables please read more abou it at the official web page on Statistics Sweden web site at [www.scb.se/px-web](https://www.scb.se/px-web).

## Current activities
We are currently porting the core part of PxWeb, which we call Px framework to .NET Standard. At the same time, we split up this core parts to individual nuget packages. Thereby making them more reusable for other applications. This is the first step of what we call PxWeb NextGen where we will rewrite the UI using new technologies and leaving the old ASP.NET Web Forms behind.
Please head over to the netstandard branch to see the activities.

## Installation
If you are looking for a compiled version of the source, ready to install in your environment. Then please send a mail to [pc-axis@scb.se](mailto:pc-axis@scb.se?subject=Access%20to%20download%20portal) and you will receive credentials to Statistics Sweden’s download portal where you can download a complied version together with instructions.

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
