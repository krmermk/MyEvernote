using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("Liked")]
    public class Liked
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int NoteID { get; set; }
        public int EvernoteUserID { get; set; }


        public virtual Note NvgNote { get; set; }
        public virtual EvernoteUser NvgEverUser { get; set; }
    }
}
