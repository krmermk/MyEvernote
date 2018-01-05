using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    public class BaseEntity
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        private DateTime _createdOn = DateTime.Now;        
        public DateTime CreatedOn
        {
            get { return _createdOn; }
            set { _createdOn = value; }
        }
        public DateTime ModifiedOn { get; set; }

        [Required,StringLength(30)]
        
        public string ModifiedUser { get; set; }
     
        private bool isDelted = false;
        public bool IsDeleted
        {
            get { return isDelted; }
            set { isDelted = value; }
        }
        
    }
}
