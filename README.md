[![Build Status](https://travis-ci.org/runejo/PxWeb.svg?branch=master)](https://travis-ci.org/runejo/PxWeb)
[![Dependabot Status](https://api.dependabot.com/badges/status?host=github&repo=runejo/PxWeb)](https://dependabot.com)
[![Maintainability](https://api.codeclimate.com/v1/badges/d46673e9ae35d2a6bdd6/maintainability)](https://codeclimate.com/github/runejo/PxWeb/maintainability)

# PxWeb
This repository currently contains the source code for PxWeb 2020 v1.
The next step is to add/move all the fixes in this version from our other repository to this one as soon as possible and there by making this repository the official PxWeb repository.

## Test with Docker
Create a Docker image and run it for easy testing

> **_NOTE:_**  Images require [Docker](https://hub.docker.com/?overlay=onboarding) running on a Windows host with hardware virtualization enabled in BIOS settings

```
docker build -t pxweb .
docker run -p 80:80 pxweb
```
## Test with Azure App Service

* [Terraform App Service with Docker](terraform/azurerm/app-service)
* [Terraform App Service with GitHub](terraform/azurerm/app-service-code)

## Test with Azure Kubernetes Service (AKS) 

* [Terraform AKS](terraform/azurerm/kubernetes) (work in progress)
This is the official source code repository for PxWeb. PxWeb is a web application for dissemination of statistical tables please read more abou it at the official web page on Statistics Sweden web site at [www.scb.se/px-web](https://www.scb.se/px-web).

## Current activities
We are currently porting the core part of PxWeb, which we call Px framework to .NET Standard. At the same time, we split up this core parts to individual nuget packages. Thereby making them more reusable for other applications. This is the first step of what we call PxWeb NextGen where we will rewrite the UI using new technologies and leaving the old ASP.NET Web Forms behind.
Please head over to the netstandard branch to see the activities.

## Compiling the source
To be able to compile the master branch you have to generate your own set of signing keys and add them to the relevant places. If you do not want to bother it that we suggest that you try out the netstandard branch where we have removed the signing of the assemblies.

## Installation
If you are looking for a compiled version of the source, ready to install in your environment. Then please send a mail to [pc-axis@scb.se](mailto:pc-axis@scb.se?subject=Access%20to%20download%20portal) and you will receive credentials to Statistics Sweden’s download portal where you can download a complied version together with instructions.
