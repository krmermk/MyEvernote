using MyEvernote.Entities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    //KeyValuePair:içerisine İki farklı tipalabiliyor.
    public class Result<T> where T : class
    {
        public List<KeyValuePair<ErrorMessageCode,string>> Errors { get; set; }
        public T Results { get; set; }
        public Result()
        {
            Errors = new List<KeyValuePair<ErrorMessageCode, string>>();
        }
        public void AddError(ErrorMessageCode code,string message)
        {
            Errors.Add(new KeyValuePair<ErrorMessageCode, string>(code, message));
        }
    }
}
