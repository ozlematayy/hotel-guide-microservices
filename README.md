# Hotel Guide Microservices Project

- Projede kullanılan teknolojiler: .NET Core , SQL Server, RabbitMQ, Logging. 
- Temelde 4 ana klasör içermektedir: ApiGateways, BuildingBlocks, Clients, Services.

## Proje Yapısı

### 1. ApiGateways

Bu klasörde basit bir Ocelot yapılanması bulunmaktadır. Ocelot, mikroservis mimarilerinde API Gateway görevini üstlenmektedir. 

### 2. BuildingBlocks

Bu klasör içerisinde yer alan EventBus klasörü, RabbitMQ üzerinde çalışan bir olay yönetim sistemini içerir.

* **Base**: Temel olay (event) sınıflarını ve işlemlerini içerir.
* **Factory**: Olayları yaratmak için kullanılan bir fabrika sınıfını içerir.
* **RabbitMQ**: RabbitMQ ile etkileşim için gerekli sınıfları içerir.


### 3. Clients

Bu klasör, harici servislerle etkileşim kurmak için kullanılan istemci uygulamalarını içerir.

### 4. Services

Bu klasör, proje içindeki ana iş mantığını barındırır. İki ana servis içerir:

- **Hotel:** Otel işlemlerini yöneten servis.
- **Report:** Rapor işlemlerini yöneten servis.

## Başlangıç

**Projeyi Klonlayın:**  

*Projede yer alan eksiklikler sebebiyle, projeyi şu anda çalıştırmak mümkün değildir. Projeyi tamamlamak için üzerinde çalışılmaya devam edilecektir.*

   ```bash
   git clone https://github.com/ozlematayy/hotel-guide-microservices/tree/ozlem
