# Todo List API - Technical Test

Repositori ini berisi implementasi REST API sederhana untuk pengelolaan Todo List, yang dibangun sebagai bagian dari seleksi magang di **PT. Acarya Data Esa**.

## 🚀 Tech Stack
- **Framework:** .NET 8 (ASP.NET Core Web API)
- **Database:** SQLite (File-based)
- **ORM:** Entity Framework Core
- **Documentation:** Swagger / OpenAPI

## 🏗️ Architectural Decisions
- **Layered Structure:** Mengikuti standar minimal requirement (/Controllers, /Models, /Data).
- **DTO Pattern:** Menggunakan Data Transfer Object untuk validasi input dan keamanan data (mencegah *mass-assignment vulnerability*).
- **Asynchronous Programming:** Menggunakan `async/await` pada semua operasi I/O untuk memastikan aplikasi tetap scalable.
- **Guid as Primary Key:** Menggunakan GUID untuk keamanan dan fleksibilitas data jangka panjang.

## 🛠️ Cara Menjalankan Project

1. **Clone Repository**
   ```bash
   git clone [https://github.com/aboutdodii/dodik_bima_todolist.git](https://github.com/aboutdodii/dodik_bima_todolist.git)
   cd dodik_bima_todolist
   
Restore Dependencies

```bash
dotnet restore
Database Migration 
```
Pastikan tool dotnet-ef sudah terinstall, lalu jalankan:

```bash
dotnet ef database update
```

Running the App

```bash
dotnet run
```
Setelah running, API dapat diakses melalui: https://localhost:****/swagger (port yang tertera di terminal).

📝 API Endpoints
GET /api/todos - Mengambil semua daftar todo (Terbaru di atas).

POST /api/todos - Membuat todo baru.

GET /api/todos/{id} - Mengambil detail todo berdasarkan ID.

PUT /api/todos/{id}/complete - Menandai todo sebagai selesai.

DELETE /api/todos/{id} - Menghapus todo.
