using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("EvernoteUser")]
    public class EvernoteUser : BaseEntity
    {
        [StringLength(25)]
        public string Name { get; set; }
        [StringLength(25)]
        public string Surname { get; set; }
        [Required,StringLength(30)]
        public string UserName { get; set; }
        [Required,StringLength(100)]
        public string Email { get; set; }
        [Required,StringLength(30)]
        public string Password { get; set; }

     

        [Required]
        public Guid ActivateGuid { get; set; }
        private bool _isAdmin = false;
        public bool isAdmin
        {
            get { return _isAdmin; }
            set { _isAdmin = value; }
        }

        private bool _isActive = false;
        public bool isActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        //Notes NvgNotes 
        //Comments NvgComment
        public virtual ICollection<Note> NvgNote { get; set; }
        public virtual ICollection<EvernoteComment> NvgComment { get; set; }
        public virtual ICollection<Liked> NvgLiked { get; set; }
    }
}
