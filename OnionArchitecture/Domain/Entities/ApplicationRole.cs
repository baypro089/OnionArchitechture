using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        // Các thuộc tính tùy chỉnh cho role (nếu cần)
        public string Description { get; set; }
    }
}
