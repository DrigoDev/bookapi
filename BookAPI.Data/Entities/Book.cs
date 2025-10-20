using System.ComponentModel.DataAnnotations;

namespace BookAPI.Data.Entities
{
    public class Book
    {
        public int Id { get; set; }
        [MaxLength(50)]        
        public string Name { get; set; }
        public bool IsBooked { get; set; } = false;
    }
}
