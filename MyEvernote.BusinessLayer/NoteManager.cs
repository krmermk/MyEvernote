using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class NoteManager
    {
        private Repository<Note> repoNote = new Repository<Note>();

        public List<Note> GetAllNote()
        {
            return repoNote.List(); 

        }

        public IQueryable<Note> GetAllNotes()
        {
            return repoNote.ListQueryable();

        }

    }
}
