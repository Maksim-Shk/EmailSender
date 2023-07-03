#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["EmailService/Server/EmailSender.Server.csproj", "EmailService/Server/"]
COPY ["EmailSender.Application/EmailSender.Application.csproj", "EmailSender.Application/"]
COPY ["EmailSender.Domain/EmailSender.Domain.csproj", "EmailSender.Domain/"]
COPY ["EmailSender.Persistence/EmailSender.Persistence.csproj", "EmailSender.Persistence/"]
COPY ["EmailSender/Client/EmailSender.Client.csproj", "EmailSender/Client/"]
RUN dotnet restore "EmailService/Server/EmailSender.Server.csproj"
COPY . .
WORKDIR "/src/EmailService/Server"
RUN dotnet build "EmailSender.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmailSender.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmailSender.Server.dll"]