using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Ad"),StringLength(25,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string Name { get; set; }
        [DisplayName("Soyad"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Surname { get; set; }
        [ DisplayName("Kullanıcı Adı"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string UserName { get; set; }
        [ DisplayName("Email"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(100, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Email { get; set; }
        [ DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı gereklidir."), StringLength(30, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Password { get; set; }
        [StringLength(30)]
        public string ImagesFileName { get; set; }
        [DisplayName("Yazar Hakkında")]
        public string AboutUser { get; set; }



        [Required]
        public Guid ActivateGuid { get; set; }
        private bool _isAdmin = false;
        [DisplayName("Admin Mi?")]
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
