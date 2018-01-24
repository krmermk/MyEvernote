using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MyEvernote.Entities
{
    [Table("Category")]
    public class Category:BaseEntity
    {
        [DisplayName("Başlık"), Required(ErrorMessage = "{0} alanı boş geçilemez."),StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Title { get; set; }
        [DisplayName("Tanım"), StringLength(100,ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Description { get; set; }

        //Notes NvgNote
        public virtual ICollection<Note> NvgNote { get; set; }

        public Category()
        {
            NvgNote = new List<Note>();
        }
    }
}
