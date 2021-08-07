# MyFitnessApp

## :eyeglasses: Project Introduction

**MyFitnessApp** is my defense project for **ASP.NET Core** course at SoftUni (May-August 2021). It is a ready-to-use ASP.NET Core application.

## :pencil2: Overview
- **Initial seeding** of:
   * Ready to use administrator (username: **Admin** & password: **123456**) and common user (username: **User** & password: **123456**).
   * User roles
   * Exercises, exercise categories and exercise equipment
   * Articles and article categories
   * Forum categories
   * Foods
- The administrator is able to ban and unban users as well as to edit, delete, create and see details about products (exercises, foods, articles, forum posts etc.)
- Using of **IFormFle** for uploading images as well as option for adding image and video as a link
- Using separate storage for all **data constants**
- Using of **"one to one" relationship** between ApplicationUser and Profile entities in odrer to make register process more simple. After first log-in the user is required to fill out profile data in order to be able to use the full functionality of the application.
- Using of **AuthorizationFilterAttribute** to restrict access for logged in users which did not create profile yet.
- Using of **AuthorizationFilterAttribute** to restrict access to the full functionality of the application for logged-in but banned users.

## :hammer: Built With
- **Visual Studio Enterprise 2019**
- **StyleCop**
- **ASP.NET 5.0 MVC**
- **ASP.NET Areas**
- **MSSQL Server**
- **Bootstrap**
- **AutoMapper**
- **Unit Tests**
- **Repository Pattern**
- **Dependency Injection**
- **Integrated SendGrid API**

## :wrench: DB Diagram
![Diagram](https://user-images.githubusercontent.com/72765831/128600927-d6c5043c-48e5-43f4-9d87-be343908f97e.jpg)

## :handshake: Credits
- Using [ASP.NET Core Template](https://github.com/NikolayIT/ASP.NET-Core-Template) originally developed by:
   * [Nikolay Kostov](https://github.com/NikolayIT)
   * [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
   * [Stoyan Shopov](https://github.com/StoyanShopov)
