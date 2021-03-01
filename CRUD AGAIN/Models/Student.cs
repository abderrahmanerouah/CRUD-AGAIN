using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_AGAIN.Models
{
    public class Student
    {
       [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required] 
        public string CIN { get; set; }
        [Required]
        public string Adresse { get; set; }
        [Required]
        public int Role { get; set; }
    }
}
