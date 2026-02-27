using System.ComponentModel.DataAnnotations;

namespace Mission8_Team0306.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = "";

        public List<TaskItem> Tasks { get; set; } = new();
    }
}