# MyFitnessApp

## :eyeglasses: Project Introduction
**MyFitnessApp** is my defense project for **ASP.NET Core** course at the **Software University** (May-August 2021). It is a ready-to-use **ASP.NET 5.0 MVC** application.


## 📝 Project Overview

- **Initial seeding of:**
   * User roles
   * Exercises, exercise categories and exercise equipment
   * Articles and article categories
   * Forum categories
   * Foods
- Ready to use administrator (username: **Admin** / password: **123456**) and common user (username: **User** / password: **123456**).
- The administrator is able to ban and unban users as well as to edit, delete, create and see details about products (exercises, foods, articles, forum posts etc.)
........

## :hammer: Built with:
- **Visual Studio Enterprise 2019**

* [.NET 5.0](https://github.com/dotnet/core)
* [ASP.NET 5.0](https://github.com/dotnet/aspnetcore)
* [Visual Studio 2019](https://shop.bodybuilding.com/)
* [Entity Framework Core 5.0](https://github.com/dotnet/efcore)
* [Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [SendGrid](https://github.com/sendgrid)
* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [Bootstrap](https://github.com/twbs/bootstrap)
* [Font Awesome](https://fontawesome.com/)
* [xUnit](https://github.com/xunit/xunit)
* [Moq](https://github.com/moq/moq)


## :pencil2: Code quality 
- **Using of**
   * **ASP.NET Areas**
   * **StyleCop**
   * **Repository Pattern**
   * **Dependency Injection**
   * **IFormFle** for uploading images as well as option for adding image and video as a link
   * separate storage for all **data constants**
   * **"one to one" relationship** between **ApplicationUser** and **Profile** entities in order to have more simple and user-friendly register process. After first log-in the user is required to fill out profile data to be able to use the full functionality of the application.
   * **AuthorizationFilterAttribute** to hide the full functionality of the application for logged-in users which did not fill out the profile form.
   * **AuthorizationFilterAttribute** to restrict access to the full functionality of the application for logged-in but banned users.

## :wrench: Database Diagram
![Diagram](https://user-images.githubusercontent.com/72765831/128600927-d6c5043c-48e5-43f4-9d87-be343908f97e.jpg)

## 📸 Project screenshots
![Capture1](https://user-images.githubusercontent.com/72765831/128936592-af18480c-9e2b-4a72-89c5-e301484cc748.JPG)
![Capture2](https://user-images.githubusercontent.com/72765831/128936595-7fc6bcd6-0ffd-4d85-a808-aa6585aaa36a.JPG)
![Capture3](https://user-images.githubusercontent.com/72765831/128936596-1663ddbf-1ea7-4fdb-987c-2532ce470136.JPG)
![Capture4](https://user-images.githubusercontent.com/72765831/128936598-8c37505c-1f76-405b-aebd-9d326e348348.JPG)
![Capture6](https://user-images.githubusercontent.com/72765831/128936601-a7b5be58-fb91-4951-bd3c-d527928dea01.JPG)
![Capture5](https://user-images.githubusercontent.com/72765831/128936602-a815a162-b248-4579-8325-61815af3fa79.JPG)
![Capture7](https://user-images.githubusercontent.com/72765831/128936604-369bc1b6-c2e7-43dc-a657-357c4096de2c.JPG)
![Capture8](https://user-images.githubusercontent.com/72765831/128936607-b9994215-612d-4b0d-b43d-273e8a6b9883.JPG)
![Capture9](https://user-images.githubusercontent.com/72765831/128936609-71f5abac-4bd1-4cc0-ad22-93e8f8125f85.JPG)


## :handshake: Credits
- Using [ASP.NET Core Template](https://github.com/NikolayIT/ASP.NET-Core-Template) originally developed by:
   * [Nikolay Kostov](https://github.com/NikolayIT)
   * [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
   * [Stoyan Shopov](https://github.com/StoyanShopov)
