using APICatalogo.Models;
using System.ComponentModel.DataAnnotations;

namespace APICatalogo.DTOs;

public class StudentDTO
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Modulo { get; set; }
    public string? Status { get; set; }
    public string? Password { get; set; }
    public ICollection<Post>? Posts { get; }
}
