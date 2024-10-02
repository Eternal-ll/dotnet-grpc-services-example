# dotnet-grpc-services-example

## Архитектура

![](/docs/overall_architecture.drawio.png)

## Структура решения
### GatewayService - шлюз
Сервис шлюз - единая точка входа для внешних систем для работы с сервисами

### ApplicationsService - сервис заявлений
Сервис по работе с заявлениями - приём заявлений на выпуск/перевыпуск карты

### CardsService - сервис карточных продуктов
Сервис по работе с картами - учёт карт

#### CardsService.Api
GRPC сервис

#### CardsService.Sdk
.NET 2.0 SDK библиотека для работы с сервисом по работе с картами через HTTP/2 GRPC

## Backlog

[https://github.com/Eternal-ll/dotnet-grpc-services-example/labels/enhancement](https://github.com/Eternal-ll/dotnet-grpc-services-example/labels/enhancement)
