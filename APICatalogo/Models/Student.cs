using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APICatalogo.Models;

[Table("Students")]
public class Student
{
    public Student()
    {
        Posts = new Collection<Post>();
    }
    public int StudentId { get; set; }
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required(ErrorMessage = "O email é obrigatório")]
    [StringLength(80)]
    public string? Email { get; set; }
    [Required]
    [StringLength(80)]
    public string? Modulo { get; set; }
    [Required]
    [StringLength(150)]
    public string? Status { get; set; }
    [Required]
    [StringLength(15)]
    public string? Password { get; set; }
    public ICollection<Post>? Posts { get; }
}
