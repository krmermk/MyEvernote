using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class Result<T> where T : class
    {
        public List<string> Errors { get; set; }
        public T Results { get; set; }
        public Result()
        {
            Errors = new List<string>();
        }
    }
}
