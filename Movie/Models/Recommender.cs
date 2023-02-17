
using Microsoft.EntityFrameworkCore;

namespace Movie.Models
{
    [Keyless]
    public class Recommender
    {
        public int UserId { get; set;}
        public int MovieId { get; set;}
        public int Rating { get; set;}
    }
}
