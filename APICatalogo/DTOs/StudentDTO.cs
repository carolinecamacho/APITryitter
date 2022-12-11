using APITryitter.Models;
using System.ComponentModel.DataAnnotations;

namespace APITryitter.DTOs;

public class StudentDTO
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Modulo { get; set; }
    public string? Status { get; set; }
    //public ICollection<PostDTO> Posts { get; set; }
}
