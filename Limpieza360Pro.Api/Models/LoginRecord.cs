using System;

namespace Limpieza360Pro.Api.Models
{
    public class LoginRecord
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime? LogoutTime { get; set; }
    }
}