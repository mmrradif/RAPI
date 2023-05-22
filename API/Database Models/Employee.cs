using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Database_Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;


        [Required]
        [Column(TypeName ="date")]
        [DisplayFormat(DataFormatString ="{0:dd-MM-yyyy}")]
        public DateTime JoiningDate { get; set; }

        [Required]
        public decimal Salary { get; set; }


        [Required]
        public Boolean IsManager { get; set; }
    }
}
