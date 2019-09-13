[![Build Status](https://travis-ci.org/runejo/PxWeb.svg?branch=master)](https://travis-ci.org/runejo/PxWeb)

# PxWeb
This repository currently only contains the source code for PxWeb 2019 v1.
The next step is to add/move all the fixes in this version from our other repository to this one as soon as possible and there by making this repository the official PxWeb repository.

## Test with Docker
Create a Docker image and run it for easy testing

> **_NOTE:_**  Images require Docker running on a Windows host

```
docker build -t pxweb .
docker run -p 80:80 pxweb
```
