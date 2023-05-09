using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class WorkRequest
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [MaxLength(1000)]
        public string Requirements { get; set; } = string.Empty;
        [Required]
        [DefaultValue(0)]
        public byte Status { get; set; }
    }
}
