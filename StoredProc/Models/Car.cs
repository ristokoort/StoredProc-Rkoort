using Microsoft.EntityFrameworkCore;

namespace StoredProc.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
    }
}
