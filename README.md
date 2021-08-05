# MyFitnessApp

## :eyeglasses: Project Introduction

**MyFitnessApp** is my defense project for **ASP.NET Core** course at SoftUni (May-August 2021). It is a ready-to-use ASP.NET Core application.

## :pencil2: Overview
TBA....

## :hammer: Built With
- **Visual Studio Enterprise 2019**
- **StyleCop**
- **ASP.NET 5.0 MVC**
- **ASP.NET View Components & Partial Views**
- **ASP.NET Areas** with integrated Admin Area
- **MSSQL Server**
- **Bootstrap**
- **AutoMapper**
- **Unit Tests**
- **Repository Pattern**
- **Dependency Injection**
- **Integrated SendGrid API** giving users the option to send E-mails.
- **Initial seeding** of administrator profile, common user profile, sample images & videos
- Using of **IFormFle** for uploading images as well as option for adding image and video as a link
- Using separate storage for all **data constants**
- Using of **"one to one" relationship** between ApplicationUser and Profile entities in odrer to make register process more simple. After first log-in the user is required to fill out profile data in order to be able to use the full functionality of the application.
- Using of **AuthorizationFilterAttribute** to restrict access for logged in users which did not create profile yet.
- Using of **AuthorizationFilterAttribute** to restrict access to the full functionality of the application for logged-in but banned users.
- Administrator and a User profile are seeded during the first start of the application.
- The Administrator is able to ban and unban users as well as to edit, delete and create new products (exercises, foods, articles, forum posts etc.)
- Administrator's username: **Admin** / password: **123456**
- User's username: **User** / password: **123456**
## :wrench: DB Diagram
TBA....

## :handshake: Credits

- [ASP.NET-MVC-Template](https://github.com/NikolayIT/ASP.NET-Core-Template) originally developed by:
   * [Nikolay Kostov](https://github.com/NikolayIT)
   * [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
   * [Stoyan Shopov](https://github.com/StoyanShopov)
