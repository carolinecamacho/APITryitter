﻿using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace APITryitter.Models;

public class Student
{
    public Student()
    {
        Posts = new Collection<Post>();
    }
    public int StudentId { get; set; }
    [Required]
    [StringLength(80)]
    public string? Name { get; set; }
    [Required]
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
