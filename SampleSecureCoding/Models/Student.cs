using System;
using System.ComponentModel.DataAnnotations;

namespace SampleSecureCoding.Models;

    public class Student
    {
        [Key]
        public string NIM { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }