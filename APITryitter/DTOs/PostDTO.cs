using System.ComponentModel.DataAnnotations;

namespace APITryitter.DTOs;

public class PostDTO
{
    public int PostId { get; set; }
    public string? Content { get; set; }
    public string? ImageUrl { get; set; }
    public int StudentId { get; set; }
}
