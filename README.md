# ExtremeVacation

This is a project that I made just for fun, or rather to practice building a fullstack .NET application with Blazor. You can use it to book (not for real) your extreme vacation like in a burning city or sharing a den with a bear. 
![Home](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/abc8c924-a2cf-44bd-be21-45749c3f923d)

The project is hosted in Azure, the backend was created using the ASP.NET Core Web API template and the frontend was made with Blazor WebAssembly. The data is stored in a SQL Server database. I used Entity Framework Core as the ORM.

By clicking on an item you can go to its details page. 
![Details](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/b6c3a39b-c57e-483f-9ce3-3ced0a7f1158)

There you can see some info about the destination and add it to your cart. 
![Cart](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/9d4b9583-d22f-4945-9958-f3fe10235ae3)

If you add the vacation to your cart, you can cancel it or proceed to checkout. If you do the latter, you’ll just be shown a message.

In the upper right corner you can see your cart. You can always click it to see what trips you’ve booked so far.

You can use the sidebar to filter the trips by category. 

## SOME TECHNICALITIES:

The solution contains three projects: 
- the Blazor WebAssembly project for the frontend,
- the ASP.NET Core Web API project for the backend,  
- the Models project for the DTOs.

I added the Entities folder to the API project with the following classes:
- Trip
- TripCategory
- Cart
- CartItem

![API](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/6a96ef6a-ff63-4012-81dc-bb34393fc6aa)

The backend project uses Entity Framework and the Microsoft SQL Server database (initially seeded with some data by overriding the OnModelCreating method in the DbContext class).
![Schemas](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/5114bf4f-8ab3-4ce8-8d98-aaa1baffafd7)

The Models project contains the following Data Transfer Object (dto) classes:
- TripDto
- TripCategoryDto
- CartItemDto
- CartItemToAddDto

I used the Repository design pattern by creating the following repositories:
- TripRepository
- CartRepository
They implement the corresponding interfaces. The repositories are registered for dependency injection in the Program class.

I created the following controller classes:
- TripController
- CartController

I created some extension methods to convert data to DTOs.

In the Blazor WebAssembly project I created the Services folder for classes to handle interactions with the Web API component. In particular, there are the following services:
- TripService
- CartService
- ManageTripLocalStorageService
- ManageCartItemLocalStorageService
They implement the corresponding interfaces.

There are methods that let you do the following with trips:
- retrieve all the trips,
- retrieve trips by category,
- retrieve trip categories,
- retrieve one particular trip by its id

![Filter](https://github.com/prospero-apps/ExtremeVacation/assets/48125733/50da1ddc-defb-4403-91b6-df1da7283591)

As far as the cart is concerned, you can do the following:
- add a cart item,
- delete a cart item,
- retrieve all cart items

Most razor components inherit from corresponding base classes that themselves inherit from ComponentBase. Some minor components have both HTML and code in one file. The components are saved in the Pages folder. The appropriate services are injected in the appropriate classes. 

For styling I used Bootstrap as well as some custom styles. The latter are added in the app.css file if they are used by more than one component or component-wise for individual components. 
I also created a LoadingSpinner component that you can see while the data is being fetched from the API.

The API project is deployed to Azure App Service and the Blazor WebAssembly project is deployed to Azure Static Web Apps.
