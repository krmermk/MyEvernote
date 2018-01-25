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
    public class BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        private DateTime _createdOn = DateTime.Now;
        private DateTime _modifiedOn = DateTime.Now;
        private bool _isDelted = false;

        [DisplayName("Eklenme Tarihi")]
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        [DisplayName("Düzenlenme Tarihi")]
        public DateTime ModifiedOn
        {
            get { return _modifiedOn; }
            set { _modifiedOn = value; }
        }

        [Required, StringLength(30),DisplayName("Düzenleyen Kisi Adı")]
        public string ModifiedUser { get; set; }

        [DisplayName("Silinmiş Mi?")]
        public bool IsDeleted
        {
            get { return _isDelted; }
            set { _isDelted = value; }
        }

    }
}
