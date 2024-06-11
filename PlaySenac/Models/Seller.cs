using System.ComponentModel.DataAnnotations;

namespace PlaySenac.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Display(Name="Full Name")]
        [Required]
        [MinLength(2), MaxLength(30)]
        public string Name { get; set; }
        [EmailAddress]
        [MinLength(6, ErrorMessage="Insira um email com mais caracteres")]
        [MaxLength(30, ErrorMessage ="Email muito lomgo")]
        public string Email { get; set; }
        [Display(Name="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [DisplayFormat(DataFormatString ="{0:#,##0.00}")]
        public double Salary { get; set; }

        [Display(Name = "Department Name")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public List<SalesRecord> Sales { get; set; } 
            = new List<SalesRecord>();
    }
}
