FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore XcaInteropService.WebService/XcaInteropService.WebService.csproj
RUN dotnet publish XcaInteropService.WebService/XcaInteropService.WebService.csproj -c Release -o /app

COPY XcaInteropService.Source/Data /app/Data

FROM mcr.microsoft.com/dotnet/aspnet:9.0

WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "XcaInteropService.WebService.dll"]
