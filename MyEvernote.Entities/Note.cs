using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.Entities
{
    [Table("Note")]
    public class Note : BaseEntity
    {
        public Note()
        {
            NvgComment = new List<EvernoteComment>();
            NvgLiked = new List<Liked>();

        }
        [Required, StringLength(60)]
        public string Title { get; set; }

        [Required, StringLength(600)]
        public string Text { get; set; }

        public int CategoryID { get; set; }
        public int EvernoteUserID { get; set; }

        private int _likeCount = 0;
        public int LikeCount
        {
            get { return _likeCount; }
            set { _likeCount = value; }
        }

        //Owner NvgUser
        public virtual EvernoteUser NvgUser { get; set; }
        public virtual Category NvgCategory { get; set; }

        public virtual ICollection<EvernoteComment> NvgComment { get; set; }
        public virtual ICollection<Liked> NvgLiked { get; set; }

        
    }
}
