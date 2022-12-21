# Documentation Money Manager App

## Overview About This Project
This app is a simple money manager app that can help you to manage your money <br>
This app was developed using NET Framework and ASP NET Core <br>
There is two solution that you can run, the first one is the backend and the second one is the frontend <br>
1. Backend is wrapped through MoneyManagerBackend Solution that you can find on backend folder. This solution contains connection to database using Entity Framework Core and Web API's to fulfilled Create, Read, Update, and Delete Request from frontend <br>
2. Frontend is wrapped through frontend Solution that you can find on frontend folder. This solution contains the UI of the app and the connection to backend using Web API's <br>

<br>

## Quick Quide on How to Run This Project
1. Clone this repository to your local machine <br>
2. Open MoneyManagerBackend solution located on backend folder. You can open this solution using Visual Studio 2022<br>
3. Please open appsettings.json. Located on backend/ClientDataAPI/appsettings.json. You can change the connection string to your local database. To do this, please change ClientContext and point to your local database. There is also provided database that you can use, located on backend/ClientDataAPI/ClientDetails.mdf<br>
4. After you change the connection string, please run the solution. Since this app wrapped using Web API's, your Visual Studio will automatically open SwaggerUI on your localhost. Usually it is opened on port 7118. You can access by typing `https://localhost:7118/swagger/index.html`<br>
5. Open frontend solution located on frontend folder. You can open this solution using Visual Studio 2022. Then you can run this solution. Visual Studio will automatically open WPF app that contains UI of this app<br>
6. You can use this app by clicking the button on the UI. You can add new client, add new transaction, and see the transaction history<br>

<br>

## Additional Notes
1. Here is some example to change Database Directory. If you haven't change the directory yet, the directory will be something look like this <br><br>
`"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Kuliah\\Materi dan Tugas\\Sem 3\\Pemrograman Berbasis Obyek\\Source\\MoneyManager-Monorepo\\moneymanager-aspnet\\backend\\ClientDataAPI\\ClientDetails.mdf\";Trusted_Connection=True;MultipleActiveResultSets=true"` <br><br>
If you look closely, you can see that there is a directory that point to the database. You can change this directory to your local database directory. For example, if you want to change the directory to `C:\\Users\\User\\Documents\\ClientDetails.mdf`, you can change the directory to <br><br>
`"Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\User\\Documents\\ClientDetails.mdf\";Trusted_Connection=True;MultipleActiveResultSets=true"` <br> <br>
2. If you have any question, please kindly inform us

<br>

## Contributors
1. Agustinus Angelo Christian Fernando (21/473804/TK/52235)
2. Aufa Nasywa Rahman (21/475255/TK/52454)
3. Ahmad Zaki Akmal (21/480179/TK/52981)
<br><br>
<i>This project was created to fulfilled Final Project of Object Oriented Programming Course</i>