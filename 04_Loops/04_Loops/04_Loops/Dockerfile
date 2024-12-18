# Hata ayıklama kapsayıcınızı özelleştirme ve Visual Studio’nun daha hızlı hata ayıklama için görüntülerinizi derlemek üzere bu Dockerfile'ı nasıl kullandığı hakkında bilgi edinmek için https://aka.ms/customizecontainer sayfasına bakın.

# Kapsayıcıları oluşturan veya çalıştıran konak makinelerinin işletim sistemine bağlı olarak FROM deyiminde belirtilen görüntünün değiştirilmesi gerekir.
# Daha fazla bilgi edinmek için https://aka.ms/containercompat sayfasına bakın

# Bu aşama, VS'den hızlı modda çalıştırıldığında kullanılır (Hata ayıklama yapılandırması için varsayılan olarak ayarlıdır)
FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app


# Bu aşama, hizmet projesini oluşturmak için kullanılır
FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["04_Loops/04_Loops.csproj", "04_Loops/"]
RUN dotnet restore "./04_Loops/04_Loops.csproj"
COPY . .
WORKDIR "/src/04_Loops"
RUN dotnet build "./04_Loops.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# Bu aşama, son aşamaya kopyalanacak hizmet projesini yayımlamak için kullanılır
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./04_Loops.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# Bu aşama üretimde veya VS'den normal modda çalıştırıldığında kullanılır (Hata Ayıklama yapılandırması kullanılmazken varsayılan olarak ayarlıdır)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "04_Loops.dll"]