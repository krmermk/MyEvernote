using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("EvernoteComment")]
    public class EvernoteComment : BaseEntity
    {
        public int NoteID { get; set; }
        public int EvernoteUserID { get; set; }

        [Required,StringLength(300)]
        public string Text { get; set; }
        

        public virtual Note NvgNote { get; set; }
        public virtual EvernoteUser NvgUser { get; set; }

    }
}
