FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use a imagem base do .NET SDK para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar o arquivo .csproj para dentro do contêiner (ajuste o caminho conforme necessário)
COPY ["C:/Users/pc/RiderProjects/CafeCentral/CafeCentral.csproj", "./"]

# Restaurar as dependências do projeto
RUN dotnet restore "CafeCentral.csproj"

# Copiar o restante dos arquivos do projeto
COPY . .

# Construir o projeto no modo Release
RUN dotnet build "CafeCentral.csproj" -c Release -o /app/build

# Publicar a aplicação no modo Release
RUN dotnet publish "CafeCentral.csproj" -c Release -o /app/publish

# Definir a imagem base para o ambiente de execução
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 80

# Copiar os arquivos publicados da fase anterior
COPY --from=build /app/publish .

# Definir o comando para rodar o aplicativo
ENTRYPOINT ["dotnet", "CafeCentral.dll"]
