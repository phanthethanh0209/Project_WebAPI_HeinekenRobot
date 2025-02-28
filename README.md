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
│-- Authorization/       # Xác thực và phân quyền
│-- Controllers/         # Xử lý yêu cầu và trả về phản hồi cho client
│-- DTO/                 # Data Transfer Objects
│-- Data/                # DbContext và cấu hình Entity Framework Core
│-- Mapper/              # Cấu hình AutoMapper
│-- Migrations/          # Lưu trữ các migration của cơ sở dữ liệu
│-- Properties/          # Cấu hình dự án
│-- Repository/          # Repository Pattern
│-- Services/            # Chứa logic nghiệp vụ
│-- Validation/          # Kiểm tra dữ liệu đầu vào
│-- Program.cs           # Cấu hình ứng dụng
│-- TheThanh_WebAPI_RobotHeineken.csproj  # File cấu hình dự án
│-- appsettings.json     # Cấu hình cơ sở dữ liệu và JWT
```

## 🔑 Chức năng chính
✅ **Quản lý thiết bị**: Robot & Máy tái chế (Thêm, sửa, xóa, danh sách)  
✅ **Quản lý địa điểm**: Khu vực, thành phố, vị trí đặt thiết bị  
✅ **Hệ thống phần thưởng**: Quản lý quà tặng  
✅ **Xác thực & Phân quyền**: JWT Authentication, Refresh Token, Custom Authorization  
✅ **Theo dõi lịch sử**: Ghi nhận lịch sử tái chế, quà tặng đã trao  

## 🔧 Hướng dẫn cài đặt
### 1️⃣ Clone repository
```console
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
- Mở **Package Manager Console** (Tools > NuGet Package Manager > Package Manager Console) và chạy lệnh sau để tạo cơ sở dữ liệu:
```powershell
Update-Database
```
- Nếu chưa có migration, tạo migration đầu tiên:
```powershell
Add-Migration InitialCreate
```
- Sau đó, cập nhật database:
```powershell
Update-Database
```

Ứng dụng sẽ chạy trên **https://localhost:5001** hoặc **http://localhost:5000**.

## 📖 API Documentation
Sử dụng **Swagger** để xem tài liệu API:
- Truy cập: [http://localhost:5000/swagger](http://localhost:5000/swagger)

Hoặc sử dụng **Postman** để kiểm thử API

## 🛠 Đóng góp
Nếu bạn muốn đóng góp, hãy tạo **Pull Request** hoặc báo lỗi trong mục **Issues** của GitHub.
