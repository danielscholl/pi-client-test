# escape=`
FROM osi-sdk:4.7.2 AS builder

WORKDIR C:\src\edge-module

COPY SimulatedTemperatureSensor.sln .
COPY Microsoft.Azure.Devices.Edge.ModuleUtil Microsoft.Azure.Devices.Edge.ModuleUtil
COPY Microsoft.Azure.Devices.Edge.Util Microsoft.Azure.Devices.Edge.Util
COPY SimulatedTemperatureSensor SimulatedTemperatureSensor

RUN nuget restore
RUN MSBuild.exe SimulatedTemperatureSensor.sln /t:restore
RUN MSBuild.exe SimulatedTemperatureSensor.sln /t:build /p:Configuration=Release /p:OutputPath=C:\out

# app image
FROM osi-runtime:4.7.2
WORKDIR C:\edge-module  
COPY --from=builder C:\out .  
ENTRYPOINT ["SimulatedTemperatureSensor.exe"] 

# docker build -f module.Dockerfile -t custom-win-sensor:latest .