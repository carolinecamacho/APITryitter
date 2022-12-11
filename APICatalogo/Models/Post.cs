using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace APITryitter.Models
{
    [Table("Posts")]
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "O Conteúdo deve ter no máximo {1} caracteres")]
        public string? Content { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 10)]
        public string? ImageUrl { get; set; }
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }
    }
}
