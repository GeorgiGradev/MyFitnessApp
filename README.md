# MyFitnessApp

## :eyeglasses: Project Introduction
This is my final project from the **ASP.NET Core** course at the **Software University**. It is a ready-to-use **ASP.NET 5.0 MVC** application.
<br/><br/>

## 📝 Project Overview
-	**MyFitnessApp** is a ready to use application for fitness and nutrition which is easy to use and has a simple user-friendly interface. The backend is developed with MS SQL and Entity Framework Core, and the frontend is built with Bootstrap (Java Script improvements are comming soon).
-	The application requires a simple registration process. More user information must be filled after the first log-in. Creating a user’s profile is obligatory and only users with active profiles can enjoy the full functionallity of the application.
-	Users can create and search for foods and exercises but do not have the possibility to edit or delete them due to the fact that other user may already use them. Only the administrator can delete foods and exercises in case they consist of inappropriate content.
-	Users can generate eating and workout plans (diaries) which can be edited and deleted.
-	Users can create, edit, delete, search and see details about forum posts, forum post comments and blog articles. Before deletion a pop up window asks for confirmation
-	Users can follow and unfollow another users. They can also send Emails to another users thanks to the integrated SendGrid client.
-	The administrator has a special Admin Area from where he/she can create, update, delete and see details about users, foods, exercises, articles and forum posts. The administrator can also ban and unban users. A banned user cannot access the full functionallity of the application.
-	The application has preloaded (seeded) user roles, users (admin and user), foods, exercises, exercise categories, exercise equipment, articles, article categories and forum categories.
<br/><br/>

## 🔗 **Link to the project**
&nbsp;&nbsp;&nbsp;&nbsp;**[myfitness-app.azurewebsites.net](https://myfitness-app.azurewebsites.net/)**
<br/><br/>

## 🧪 Test Accounts
&nbsp;&nbsp;&nbsp;&nbsp;Username: **admin**  
&nbsp;&nbsp;&nbsp;&nbsp;Password: **123456**  

&nbsp;&nbsp;&nbsp;&nbsp;Username: **user**  
&nbsp;&nbsp;&nbsp;&nbsp;Password: **123456** 
<br/><br/>

## :hammer: Built with:
* [ASP.NET 5.0](https://github.com/dotnet/aspnetcore)
* [Visual Studio 2019](https://github.com/github/VisualStudio)
* [Entity Framework Core 5.0](https://github.com/dotnet/efcore)
* [Sql Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
* [SendGrid](https://github.com/sendgrid)
* [AutoMapper](https://github.com/AutoMapper/AutoMapper)
* [Bootstrap](https://github.com/twbs/bootstrap)
* [Font Awesome](https://fontawesome.com/)
* [xUnit](https://github.com/xunit/xunit)
* [Moq](https://github.com/moq/moq)
<br/><br/>

## :pencil2: Code quality 
- **Using of**
   * **ASP.NET Areas**
   * **StyleCop**
   * **Repository Pattern**
   * **Dependency Injection**
   * **IFormFle** for uploading of JPG images as well as an option for adding links of images and YouTube videos.
   * **Self-created method** for **embedding of raw YouTube links**.
   * **One to one** relationship between **ApplicationUser** and **Profile** entities in order to have more simple and user-friendly register process. After first log-in the user is required to fill out profile data to be able to use the full functionality of the application.
   * **AuthorizationFilterAttribute** to hide the full functionality of the application for logged-in users which haven't filled the profile form.
   * **AuthorizationFilterAttribute** to restrict the access to the full functionality of the application for logged-in but banned users.
   * Separate storage for **data constants**.
<br/><br/>

## :wrench: Database Diagram
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/Database%20Diagram%2007.08.2021.jpg" /></kbd>
<br/><br/>

## ✔️Tests Code Coverage Results
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/Test%20Code%20Coverage%2016.08.2021.PNG" /></kbd>
<br/><br/>

## 📸 Application screenshots
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/01.Home%20Page%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/02.Home%20Page%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/03.My%20Profile%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/04.All%20users%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/05.%20Muscle%20groups%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/06.All%20exercises%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/07.Exercise%20Diary%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/08.Food%20diary%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/09.Forum%20post-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/10.All%20articles%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/11.Article%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/12.Admin%20dashboard%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/13.Admin%20area%20Users%20-%20MyFitnessApp.png" /></kbd>
<br/><br/>

## :handshake: Credits
- Using [ASP.NET Core Template](https://github.com/NikolayIT/ASP.NET-Core-Template) originally developed by:
   * [Nikolay Kostov](https://github.com/NikolayIT)
   * [Vladislav Karamfilov](https://github.com/vladislav-karamfilov)
   * [Stoyan Shopov](https://github.com/StoyanShopov)
<br/><br/>

## :v: Leave a feedback
Give a :star: if you like it.
Thank you ❤️
<br/><br/>

## 📖 License
See the [LICENSE](https://github.com/GeorgiGradev/MyFitnessApp/blob/main/LICENSE) file for details
