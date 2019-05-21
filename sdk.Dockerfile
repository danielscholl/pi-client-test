# escape=`
FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2

WORKDIR C:\install
COPY sdk .
SHELL ["cmd", "/S", "/C"]
RUN Setup.exe -f silent.ini
WORKDIR C:\
RUN rmdir /s/q install

# docker build -f sdk.Dockerfile -t osi-sdk:4.7.2 .