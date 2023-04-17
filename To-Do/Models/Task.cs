using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter Task text")]
        [Column(TypeName = "nvarchar(50)")]
        public string? Content { get; set; }

        [Column(TypeName ="datetime")]
        public DateTime Created { get; set; }

        [DefaultValue(false)]
        public bool IsReady { get; set; }
    }
}
