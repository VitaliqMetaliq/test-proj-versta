# Тестовый проект

## Запуск с помощью Docker
 - *docker-compose up -d* из папки deploy
 - React приложение будет доступно на http://localhost:3000
 - ASP.NET приложение будет доступно на http://localhost:5000

## Запуск руками
 - Используется БД PostgreSQL - Поправить connection string по пути Orders.Api/Orders.Api.Main/appsettings.json (под свой хост/порт)
 - Запуск ASP.NET приложения - из папки Orders.Api/Orders.Api.Main - *dotnet run --verbosity detailed*
 - Запуск React приложение - из папки orders-app - *npm i && npm run dev*
