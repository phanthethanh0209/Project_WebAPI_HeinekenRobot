# Heineken Robot  

## 📌 Giới thiệu
Heineken Robot là một Web API được phát triển bằng **ASP.NET Core 6** nhằm quản lý hệ thống **robot và máy tái chế** trong các chiến dịch marketing của Heineken. API hỗ trợ quản lý thông tin robot, địa điểm, phần thưởng, lịch sử tái chế và nhiều chức năng khác.

## 🚀 Công nghệ sử dụng
- **.NET 6 (ASP.NET Core Web API)**
- **Entity Framework Core** (Code-First, Fluent API)
- **Microsoft SQL Server** (Lưu trữ dữ liệu)
- **AutoMapper** (Chuyển đổi dữ liệu giữa DTO và Model)
- **JWT Authentication** (Xác thực API)
- **Swagger UI** (Tài liệu API)
- **Repository Pattern** (Quản lý dữ liệu)

## 📂 Cấu trúc thư mục
```
TheThanh_WebAPI_RobotHeineken/
│-- Controllers/         # Xử lý request và trả về response cho client
│-- Data/               # DbContext và cấu hình EF Core
│-- DTOs/               # Data Transfer Objects
│-- Models/             # Các entity trong database
│-- Repositories/       # Repository Pattern
│-- Services/           # Chứa logic nghiệp vụ
│-- Validators/         # Kiểm tra dữ liệu đầu vào
│-- Program.cs          # Cấu hình ứng dụng
│-- appsettings.json    # Cấu hình database và JWT
```

## 🔑 Chức năng chính
✅ **Quản lý thiết bị**: Robot & Máy tái chế (Thêm, sửa, xóa, danh sách)  
✅ **Quản lý địa điểm**: Khu vực, thành phố, vị trí đặt thiết bị  
✅ **Hệ thống phần thưởng**: Quản lý quà tặng
✅ **Xác thực & Phân quyền**: JWT Authentication, Custome Authorization  
✅ **Theo dõi lịch sử**: Ghi nhận lịch sử tái chế, quà tặng đã trao  

## 🔧 Hướng dẫn cài đặt
### 1️⃣ Clone repository
```sh
git clone https://github.com/phanthethanh0209/Project_WebAPI_HeinekenRobot.git
cd TheThanh_WebAPI_RobotHeineken
```
### 2️⃣ Cấu hình database
- Mở **appsettings.json**, chỉnh sửa chuỗi kết nối SQL Server:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=HeinekenRobotDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```
- Chạy migration để tạo database:
```sh
dotnet ef database update
```

### 3️⃣ Chạy ứng dụng
```sh
dotnet run
```
Ứng dụng sẽ chạy trên **https://localhost:5001** hoặc **http://localhost:5000**.

## 📖 API Documentation
Sử dụng **Swagger** để xem tài liệu API:
- Truy cập: [http://localhost:5000/swagger](http://localhost:5000/swagger)

## 🛠 Đóng góp
Nếu bạn muốn đóng góp, hãy tạo **Pull Request** hoặc báo lỗi trong mục **Issues** của GitHub.
