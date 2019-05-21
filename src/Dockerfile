# escape=`

## Stage 1
FROM osi-sdk:4.7.2 AS builder
WORKDIR C:\src\edge-module
COPY . .
RUN MSBuild.exe afs.sln /t:restore
RUN MSBuild.exe afs.sln /t:build /p:Configuration=Debug /p:OutputPath=C:\out

# Stage 2
FROM osi-runtime:4.7.2
WORKDIR C:\edge-module  
COPY --from=builder C:\out .  
ENTRYPOINT ["afs.exe"] 

# docker build -f Dockerfile -t pitest:latest .