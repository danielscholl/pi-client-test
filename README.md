# Instructions

## Download PI SDK
Download the PI AF SDK and extract into a directory entitled afsdk

## Base SDK Docker file

Build the SDK Docker file
```powershell
docker build -f sdk.Dockerfile -t osi-sdk:4.7.2 .
```

## Base Runtime Docker file

Build the Runtime Docker file
```powershell
# escape=`
docker build -f runtime.Dockerfile -t osi-runtime:4.7.2 .
```

## Build the Test Code Base

Build the sample application to test pi connectivity
```powershell
docker build -f Dockerfile -t pitest:latest .
```

## Execute the Test Code Base Docker File to Test Connection

Execute the container and feed it credentials to test connectivity to PI from a Container
```powershell
# These are for Task Runner
$Env:PI_USER = "pi_user"
$Env:PI_PASSSWORD = "pi_password"
$Env:PI_DOMAIN = "pi_domain"
$Env:AF_NAME = "pi_server.com"
$Env:PI_NAME = "pi_name"

docker run -it `
    -e PI_USER=$Env:PI_USER `
    -e PI_PASSWORD=$Env:PI_PASSWORD `
    -e PI_DOMAIN=$Env:PI_DOMAIN `
    -e AF_NAME=$Env:AF_NAME `
    -e PI_NAME=$Env:PI_NAME `
    pitest:latest
```

## Build the IoT Edge Module

Build the sample application to test pi connectivity
```powershell
cd module
docker build -f module.Dockerfile -t custom-win-sensor:latest .
```

## Deploy the IoT Edge Module