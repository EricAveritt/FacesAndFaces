#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["FacesWeb/WebMvc/WebMvc.csproj", "FacesWeb/WebMvc/"]
COPY ["FacesSharedLib/MessagingInterfacesConstants/MessagingInterfacesConstants.csproj", "FacesSharedLib/MessagingInterfacesConstants/"]
RUN dotnet restore "FacesWeb/WebMvc/WebMvc.csproj"
COPY . .
WORKDIR "/src/FacesWeb/WebMvc"
RUN dotnet build "WebMvc.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebMvc.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebMvc.dll"]
