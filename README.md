db dah diganti, tp ttp perlu ubah direktori file di backend -> ClientDataAPI -> appsettings.json

<br>
<br>

ubah connection string ke directory relative yang dbnya ada di folder itu juga
<br>
cth: "ClientContext": "Server=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Kuliah\\Materi dan Tugas\\Sem 3\\Pemrograman Berbasis Obyek\\Source\\MoneyManager-Monorepo\\moneymanager-aspnet\\backend\\ClientDataAPI\\ClientDetails.mdf\";Trusted_Connection=True;MultipleActiveResultSets=true"
<br>
ubah setelah attachdbfilename= jadi relative path ke file dbnya