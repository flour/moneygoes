# FROM microsoft/dotnet:2.1-sdk-alpine AS build
# RUN ls
# RUN apk add --update nodejs
# WORKDIR /app
# COPY . .
# # copy csproj and restore as distinct layers
# RUN dotnet restore

# # copy everything else and build app
# RUN dotnet publish -c Release -o out

# FROM microsoft/dotnet:2.1-aspnetcore-runtime-alpine AS runtime
# WORKDIR /app
# COPY --from=build /app/out ./
# ENTRYPOINT ["dotnet", "moneygoes.dll"]

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet moneygoes.dll