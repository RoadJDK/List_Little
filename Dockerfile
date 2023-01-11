FROM node:alpine

WORKDIR '/app'

RUN npm install -g @angular/cli@latest

COPY package.json .

RUN npm install

RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
ENV DOTNET_URLS=http://+:5000

WORKDIR /List_Little_Api

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /List_Little_Api
COPY --from=build-env /List_Little_Api/out .
ENTRYPOINT ["dotnet", "List_Little_Api.dll"]