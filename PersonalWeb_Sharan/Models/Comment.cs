using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace PersonalWeb_Sharan.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Text is required.")]
        public required string Text { get; set; }
    }
}
