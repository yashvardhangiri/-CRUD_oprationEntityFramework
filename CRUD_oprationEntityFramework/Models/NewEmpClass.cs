using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CRUD_oprationEntityFramework.Models
{
    public class NewEmpClass
    {
        [Key]
        public int EmpId { get; set; }

        [Required(ErrorMessage ="Enter the Employee Name")]
        [Display(Name = "Employee Name")]
        public string EmpName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Please Enter The Email")]
        [Display(Name ="Email")]
        public string EmpEmail { get; set; }

        [Required(ErrorMessage = "Please Enter The Salary Amount")]
        [Display(Name = "Salary")]
        public int EmpSalary{ get; set; }


    }
}
