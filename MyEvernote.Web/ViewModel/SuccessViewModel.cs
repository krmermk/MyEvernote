using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEvernote.Web.ViewModel
{
    public class SuccessViewModel : NotifyViewModelBase<string>
    {
        public SuccessViewModel()
        {
            Title = "İşlem Başarılı";
        }
    }
}