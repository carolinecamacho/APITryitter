using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APITryitter.Models;
    public class Post
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(300)]
        public string? Content { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImageUrl { get; set; }
        public int StudentId { get; set; }

        [JsonIgnore]
        public Student? Student { get; set; }

}

