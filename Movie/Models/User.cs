using Microsoft.EntityFrameworkCore;

namespace Movie.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserType { get; set; }  
    }
}
