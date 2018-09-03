#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 22479
EXPOSE 44373

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY ["JarvisEF.FrontUI/JarvisEF.FrontUI.csproj", "JarvisEF.FrontUI/"]
RUN dotnet restore "JarvisEF.FrontUI/JarvisEF.FrontUI.csproj"
COPY . .
WORKDIR "/src/JarvisEF.FrontUI"
RUN dotnet build "JarvisEF.FrontUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "JarvisEF.FrontUI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "JarvisEF.FrontUI.dll"]