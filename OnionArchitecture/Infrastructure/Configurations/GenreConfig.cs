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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            // Khóa chính
            builder.HasKey(g => g.Id); // Id là khóa chính

            // Các thuộc tính cơ bản
            builder.Property(g => g.Name)
                .HasMaxLength(50) // giới hạn độ dài là 50 ký tự
                .IsRequired(); // yêu cầu bắt buộc

            builder.Property(g => g.Description)
                .HasColumnType("text") // Định nghĩa trường là kiểu text
                .IsRequired(false); // không yêu cầu bắt buộc (có thể null)

            builder.Property(g => g.InActive)
                .HasDefaultValue(0) // Giá trị mặc định cho InActive là 0 (có thể là inactive)
                .IsRequired(); // yêu cầu bắt buộc

        }
    }
}
