using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_lesson_csh_ado
{
    [Table("Books")]
    public class Book
    {
        [Key, Column("Id", TypeName = "int"), Required]
        public int ID { get; set; }

        [Column(TypeName = "varchar"), Required, MaxLength(20)]
        public string Title { get; set; }

        [Column("Pages", TypeName = "int"), Required]
        public int Size { get; set; }

        [Required, Range(50, 2500)]
        public double Price { get; set; }

        [ForeignKey("IdPublisher"), Column("IdPublisher")]
        public int? IDPublisher { get; set; }
        [NotMapped]
        public virtual Publisher _Publisher { get; set; }
    }
}