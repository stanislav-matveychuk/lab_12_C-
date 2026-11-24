# Лабораторна робота №12

Реалізовано сценарій Code First: ASP.NET Core Web API, EF Core SQL Server,
зв'язок Category → Products (один до багатьох), міграція InitialCreate,
категорії через HasData та товари через DbSeeder. Повторний запуск не додає
товари, якщо таблиця вже містить записи. JSON не має циклічних посилань.

## Запуск

Потрібні .NET 10 SDK та SQL Server Express LocalDB. Для іншого SQL Server
змініть ConnectionStrings:DefaultConnection у appsettings.json.
Проєкт використовує встановлений .NET 10; для роботи з ним потрібна IDE,
яка підтримує цей SDK, або командний рядок.

```powershell
cd 'D:\lab_C#_12'
dotnet tool restore
dotnet restore
dotnet ef database update
dotnet run -- --urls http://localhost:5080
```

У середовищі Development відкрийте http://localhost:5080/swagger.
При старті програма застосовує міграції та викликає Seeder.

## Перевірка сценарію

1. GET /api/categories: Electronics та Books із товарами.
2. GET /api/products: Laptop (1000), Smartphone (500), ASP.NET Core Book (30).
3. POST /api/products з тілом нижче: відповідь 201 та Location нового товару.
4. GET за Location: доданий товар; повторний запуск зберігає його.
5. Невідома CategoryId, порожня назва або від'ємна ціна: відповідь 400.
6. Для перевірки відтворення лише навчальної БД Lab12Products зупиніть API,
   виконайте `dotnet ef database drop` (видаляє всі її дані, запитує підтвердження),
   потім `dotnet ef database update` і запустіть API для наповнення товарами.

```json
{ "name": "Keyboard", "price": 75, "categoryId": 1 }
```
