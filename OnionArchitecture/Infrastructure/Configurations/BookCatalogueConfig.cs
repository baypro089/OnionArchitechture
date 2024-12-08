using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Infrastructure.Data.Configurations
{
    public class BookCatalogueConfig : IEntityTypeConfiguration<BookCatalogue>
    {
        public void Configure(EntityTypeBuilder<BookCatalogue> builder)
        {
            // Khóa chính: Có thể sử dụng khóa composite từ BookId và CatalogueId
            builder.HasKey(c => c.Id); // Khóa chính kết hợp

            // Cấu hình thuộc tính CreatedOn
            builder.Property(cb => cb.CreatedOn)
                .HasColumnType("date") // Định dạng ngày tháng
                .IsRequired(); // Yêu cầu bắt buộc

            // Cấu hình thuộc tính IsActive
            builder.Property(cb => cb.IsActive)
                .HasDefaultValue(1) // Giá trị mặc định cho IsActive là 1 (kích hoạt)
                .IsRequired(); // Yêu cầu bắt buộc

            // Cấu hình quan hệ với Book
            builder.HasOne(cb => cb.Book)
                .WithMany() // Một Book có thể có nhiều CatalogueBook
                .HasForeignKey(cb => cb.BookId) // Khóa ngoại BookId
                .OnDelete(DeleteBehavior.Cascade); // Xóa liên kết khi Book bị xóa

            // Cấu hình quan hệ với Catalogue
            builder.HasOne(cb => cb.Catalogue)
                .WithMany() // Một Catalogue có thể có nhiều CatalogueBook
                .HasForeignKey(cb => cb.CatalogueId) // Khóa ngoại CatalogueId
                .OnDelete(DeleteBehavior.Cascade); // Xóa liên kết khi Catalogue bị xóa
        }
    }
}
