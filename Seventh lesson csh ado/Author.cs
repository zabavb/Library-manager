using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seventh_lesson_csh_ado
{
    [Table("Authors")]
    public class Author
    {
        [Key, Column("Id", TypeName = "int"), Required]
        public int ID { get; set; }

        [Column("FirstName", TypeName = "varchar"), Required, MaxLength(20)]
        public string Name { get; set; }

        [Column("LastName", TypeName = "varchar"), Required, MaxLength(30)]
        public string Surname { get; set; }
    }
}