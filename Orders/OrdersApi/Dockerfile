#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:5.0-buster AS build
WORKDIR /src
COPY ["Orders/OrdersApi/OrdersApi.csproj", "Orders/OrdersApi/"]
COPY ["FacesSharedLib/MessagingInterfacesConstants/MessagingInterfacesConstants.csproj", "FacesSharedLib/MessagingInterfacesConstants/"]
RUN dotnet restore "Orders/OrdersApi/OrdersApi.csproj"
COPY . .
WORKDIR "/src/Orders/OrdersApi"
RUN dotnet build "OrdersApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrdersApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrdersApi.dll"]
