# NetProje
Projemde uygulamalı olarak birçok best pratiği .NET CORE API üzerinde uygulamalı olarak işledim. Mimari olarak NLayer Mimari kulladım. Database olarak MS SQL SERVER kullandım. ORM olarak Entity Framework Core kullandım. Projem bir araç kiralama sitesinin backend uygulamasıdır.
İşlediğim bazı best pratikler : 
1. Hata Yönetimi
2. Validasyon
3. Önbellekleme
4. Transaction Yönetimi
5. API Yönetimi ve Dökümantasyon
6. Yapılandırma Yönetimi
7. Performans Optimizasyonu
8. Dependency Injection ve IoC
9. Veri Tutarlılığı ve Zamanlanmış İşler
10. Pagination ve Filtering
11. Use DTOs ( Data Transfer Objects )
12. RESTful Api Design
13. Logging

Hafta Ödevleri. Var olan projemizi derste yaptığımız gibi katmanlı mimariye taşıyacağız. Katmanlı mimari projemizde : Fluent validation- mapper library'leri mutlaka olacak ve kullanılacaktır. Dataların Redis'ten gelmesi ile ilgili geliştirme yapılacaktır. Projede generic repository ve Unit Of Work kullanılacaktır. en az 3 tane entity olacak. Ve bu entity'ler ile ilgili custom sorgular için kendine ait repository sınıfları oluşturulacaktır. Her entity'nin CRUD endpointleri ve custom endpoint'leri olacaktır. En az 2 farklı senaryoda filter'ların kullanılması ile ilgili örnek projede bulunacaktır.

Katmanlı Mimari Projesine Serilog Entegrasyonu:

Katmanlı mimari kullandığımız mevcut projeye, Serilog kütüphanesini ekleyerek tüm hata (exception) ve log kayıtlarının SQL Server veritabanına gönderilmesini sağlayınız. Bu ödevi yaparken, Serilog konfigürasyonlarının doğru yapıldığından ve logların veritabanında düzgün bir şekilde saklandığından emin olunuz.
