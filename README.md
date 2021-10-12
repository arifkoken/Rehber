# Introduction 

Ön değerlendirme için hazırlanan min iki microservis haberleşmesi içeren küçük bir rehber uygulaması
# Getting Started
### 1.	Kurulum Adımları
- RabbitMq,Postgresql,Mssql,Rehber Api ve Rapor Api sinin ayağa kaldırılması
_Gerekli configurasyon uygulama dizininde bulunan Docker-compose.yaml dosyası içerisinde yapılmıştır. Dosyanın bulunduğu dizinde aşağıdaki kodun çalıştırılması gerekmektedir._
    ``` 
    docker-compose up
    ```
### 2.	Db'lerin ayağa kaldırılması
 _İlgili proje içerisine migration dosyarı eklenmiştir_
- Rapor servisi Db'sinin ayağa kaldırılması
_Aşağıdaki komut yardımıyla db otomatik olarak oluşturulabilir._
    ```
     update-database
    ```
- Rehber servisi Db'sinin ayağa kaldırılması
_Aşağıdaki komut yardımıyla db otomatik olarak oluşturulabilir._
    ```
    update-database
   ```
    
### 3.	Micro serviceler arası iletişim yapılandırması
_Rapor servisinin ConfigureService methodu içerisinde isteğe gör değiştirilmesi gerekiyor._
- FakeService bağlantı şekli
    ```  
    services.AddScoped<IRehberServiceAdapter, FakeRehberServiceAdapter>(); 
    ```
- GerçekService bağlantı şekli
    ```  
    services.AddScoped<IRehberServiceAdapter,RehberServiceAdapter>(); 
    ```

4.	Api Detayı
