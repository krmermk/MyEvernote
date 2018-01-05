using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("Category")]
    public class Category:BaseEntity
    {
        [Required,StringLength(50)]
        public string Title { get; set; }
        [StringLength(100)]
        public string Description { get; set; }

        //Notes NvgNote
        public virtual ICollection<Note> NvgNote { get; set; }

        public Category()
        {
            NvgNote = new List<Note>();
        }
    }
}
