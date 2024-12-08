using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            // Khóa chính
            builder.HasKey(b => b.Id); // Id là khóa chính

            // Các thuộc tính cơ bản
            builder.Property(b => b.Title)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.Author)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.Publisher)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.Price)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.CreatedOn)
                .HasColumnType("date") // Định dạng ngày tháng
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.IsActive)
                .HasDefaultValue(1) // Giá trị mặc định cho IsActive là 1 (active)
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(b => b.Available)
                .IsRequired(); // yêu cầu bắt buộc

            // Cấu hình quan hệ với Genre (Khóa ngoại)
            builder.HasOne(b => b.Genre)
                .WithMany() // Bạn có thể cấu hình quan hệ với Genre nếu cần
                .HasForeignKey(b => b.GenreId) // Liên kết khóa ngoại với GenreId
                .IsRequired(); // yêu cầu khóa ngoại bắt buộc
        }
    }
}
