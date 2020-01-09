# GORECIPE
Aplikasi dekstop untuk katalog resep masakan

## How to install
1. Import/Attach database `DB_new\GO_RECIPE_dat.mdf` dan `DB_new\GO_RECIPE_logs.ldf` ke SQL Server 2017 atau terbaru
2. Buka project `Gocip.sln` dengan Microsoft Visual Studio 2015 atau versi terbaru
3. Pada Solution Explorer, buka file `Connection\SQLConnection.cs`
4. Ubah nama sesuai SQL Server kamu pada bagian `Data Source = RIZKY\\SQLEXPRESS;`
5. Jalankan aplikasi

### User & Admin login
Buka database dengan SQL Server lalu cari pada tabel `DBO.ADMINISTRATOR` dan `DBO.CUSTOMER`
