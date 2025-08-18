# Product API Projesi

Bu proje, .NET 6 Web API kullanılarak oluşturulmuş basit bir ürün yönetim API'sidir. Temel CRUD (Create, Read, Update, Delete) işlemlerini destekler.

## Kullanılan Teknolojiler

- .NET 6 (ASP.NET Core Web API)
- C#
- Entity Framework Core
- PostgreSQL / MSSQL
- Swagger

## Kurulum ve Çalıştırma Adımları

### Ön Gereksinimler

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
-  MSSQL veritabanı sunucusu

### Kurulum

1.  **Proje Klonlama:**
    ```bash
    git clone <repository-url>
    cd ProductApi
    ```

2.  **Veritabanı Bağlantısı:**
    `appsettings.json` dosyasını açın ve `ConnectionStrings` bölümündeki `DefaultConnection` alanını kendi veritabanı sunucu bilgilerinize göre güncelleyin.

3.  **Veritabanı Migration:**
    Aşağıdaki komutları proje kök dizininde çalıştırarak veritabanını oluşturun ve şemayı uygulayın:
    
    Terminal için
    ```bash
    dotnet ef database update
    ```
    PMC için
    ```bash
    add-migration InitialCreate
    ```

5.  **Uygulamayı Çalıştırma:**
    ```bash
    dotnet run
    ```

Uygulama varsayılan olarak `https://localhost:7xxx` ve `http://localhost:5xxx` portlarında çalışmaya başlayacaktır.

API dokümantasyonuna ve test arayüzüne erişmek için tarayıcınızdan `https://localhost:7xxx/swagger` adresine gidin.
