using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        // Bạn có thể thêm các thuộc tính tùy chỉnh cho người dùng tại đây
        public string FullName { get; set; }
    }
}
