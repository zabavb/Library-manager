using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_lesson_csh_ado
{
    [Table("BookAuthors")]
    public class BookAuthor
    {
        [ForeignKey("Book_id"), Column("Book_id", TypeName = "int"), Required]
        public int? IDBook { get; set; }
        [NotMapped]
        public virtual Book _Book { get; set; }
        
        [ForeignKey("Author_id"), Column("Author_id", TypeName = "int"), Required]
        public int? IDAuthor { get; set; }
        [NotMapped]
        public virtual Author _Author { get; set; }
    }
}