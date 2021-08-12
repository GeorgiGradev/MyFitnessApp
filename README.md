# MyFitnessApp

## :eyeglasses: Project Introduction
**MyFitnessApp** is my defense project for **ASP.NET Core** course at the **Software University** (May-August 2021). It is a ready-to-use **ASP.NET 5.0 MVC** application.
<br/><br/>

## 📝 Project Overview
-	**MyFitnessApp** is a ready to use application for fitness and nutrition which is easy to use and has a simple user-friendly interface. The backend is developed on MS SQL and Entity Framework Core, and the frontend is built with Bootstrap (Java Script improvements are soon to come)
-	The application requires a simple registration process. More user information must be filled after the first log-in. Creating user’s profile is obligatory and only users with active profiles can enjoy the full functionallity of the application. 
-	Users can create and search for foods and exercises but do not have the possibility to edit or delete due to the fact that other user may already use them. Only the administrator can delete foods and exercises in case they consist of not appropriated content.
-	Users can generate eating and workout plans (diaries) which can be edited and deleted.
-	Users can create, edit, delete, search and see details about forum posts, forum post comments and blog articles. Before deletion a pop up window asks for confirmation.
-	Users can follow and unfollow another users. They can also send Emails to another users thanks to the integrated SendGrid client.
-	The administrator has a special Admin Area from where he/she can create, update, delete and see details about users, foods, exercises, articles and forum posts. The administrator can ban and unban users. A banned user cannot access the full functionallity of the application.
-	The application has preloaded (seeded) user roles, users (Admin and User), foods, exercises, exercise categories, exercise equipment, articles, article categories and forum categories.
- If you would like to test the application you can log-in with the already existing (seeded) profiles.

&nbsp;&nbsp;&nbsp;&nbsp;**Test Accounts**:

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
   * **IFormFle** for uploading of JPG images as well as an option for adding lins of images and YouTube videos
   * **Self-created method** for **embedding of raw YouTube links**
   * **One to one** relationship between **ApplicationUser** and **Profile** entities in order to have more simple and user-friendly register process. After first log-in the user is required to fill out profile data to be able to use the full functionality of the application.
   * **AuthorizationFilterAttribute** to hide the full functionality of the application for logged-in users which did not fill out the profile form.
   * **AuthorizationFilterAttribute** to restrict access to the full functionality of the application for logged-in but banned users.
   * Separate storage for **data constants**
<br/><br/>

## :wrench: Database Diagram
![Diagram](https://user-images.githubusercontent.com/72765831/128600927-d6c5043c-48e5-43f4-9d87-be343908f97e.jpg)
<br/><br/>

## ✔️Tests Code Coverage
![AppTests](https://user-images.githubusercontent.com/72765831/129061067-66fc4090-32d7-4fa2-a457-0b268c7007b4.png)
<br/><br/>

## 📸 Project screenshots
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/1.IndexPage.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/2.WelcomePage.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/3.Profile.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/4.AllUsers.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/5.AllExercises.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/6.%20ExerciseDiary.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/7..FoodDiary.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/8.Articles.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/9.ForumPost.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/10.AdminDashBoard.PNG" /></kbd>
<br/><br/>
<kbd><img src="https://github.com/GeorgiGradev/MyFitnessApp/blob/main/MyFitnessApp/AppScreenshots/11..AdminUserArea.PNG" /></kbd>
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
