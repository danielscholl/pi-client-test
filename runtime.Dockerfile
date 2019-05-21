# escape=`
FROM mcr.microsoft.com/dotnet/framework/runtime:4.7.2

WORKDIR C:\install
COPY sdk .
SHELL ["cmd", "/S", "/C"]
RUN Setup.exe -f silent.ini
WORKDIR C:\
RUN rmdir /s/q install

CMD regln HKEY_LOCAL_MACHINE\SOFTWARE\PISystem\pi-sdk HKEY_LOCAL_MACHINE\SOFTWARE\wow6432node\PISystem\pi-sdk

# docker build -f runtime.Dockerfile -t osi-runtime:4.7.2 .