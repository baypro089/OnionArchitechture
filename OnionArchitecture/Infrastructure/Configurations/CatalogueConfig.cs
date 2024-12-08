using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Configurations
{
    public class CatalogueConfig : IEntityTypeConfiguration<Catalogue>
    {
        public void Configure(EntityTypeBuilder<Catalogue> builder)
        {
            // Khóa chính
            builder.HasKey(c => c.Id); // Id là khóa chính

            // Các thuộc tính cơ bản
            builder.Property(c => c.Title)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(c => c.Description)
                .HasColumnType("text") // Định nghĩa trường là kiểu text
                .IsRequired(false); // không yêu cầu bắt buộc (có thể null)

            builder.Property(c => c.IsActive)
                .HasDefaultValue(1) // Giá trị mặc định cho IsActive là 1 (active)
                .IsRequired(); // yêu cầu bắt buộc
        }
    }
}
