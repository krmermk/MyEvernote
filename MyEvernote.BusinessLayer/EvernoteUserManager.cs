using MyEvernote.Common.Helpers;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using MyEvernote.Entities.Messages;
using MyEvernote.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernote.BusinessLayer
{
    public class EvernoteUserManager
    {
        private Repository<EvernoteUser> repoUser = new Repository<EvernoteUser>();

        public Result<EvernoteUser> RegisterUser(RegisterViewModel data)
        {
            EvernoteUser user = repoUser.Find(x => x.UserName == data.Username && x.Email == data.Email);
            Result<EvernoteUser> rs = new Result<EvernoteUser>();
            if (user != null)
            {
                if (user.UserName == data.Username)
                {
                    rs.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı Adı kayıtlı");
                }
                if (user.Email == data.Email)
                {
                    rs.AddError(ErrorMessageCode.EmailAlreadyExists, "Email adresi kayıtlı");
                }
            }
            else
            {
                int dbResult = repoUser.Insert(new EvernoteUser()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    UserName = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    isActive = false

                });
                if (dbResult > 0)
                {
                    rs.Results = repoUser.Find(x => x.Email == data.Email && x.UserName == data.Username);
                    //Kullanıcı hesabı aktifleştirmek için mail gönderme.
                    string siteUrl = ConfigHelper.Get<string>("SiteRootUrl");
                    string activeUrl = $"{siteUrl}/Register/UserActivate/{rs.Results.ActivateGuid}";
                    string body = $"Merhaba {rs.Results.Name} {rs.Results.Surname};<br><br>Hesabınızı aktifleştirmek için <a href='{activeUrl}' target='_blank'>tıklayınız</a>";
                    MailHelper.SendMail(body, rs.Results.Email, "My Evernote Hesap Aktifleştirme");
                }
            }

            return rs;
        }

        public Result<EvernoteUser> GetUserById(int id)
        {
            Result<EvernoteUser> res = new Result<EvernoteUser>();
            res.Results = repoUser.Find(x => x.ID == id && x.IsDeleted == false);
            if (res.Results == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı");
            }
            return res;
        }

        public Result<EvernoteUser> LoginUser(LoginViewModel data)
        {
            Result<EvernoteUser> loginResult = new Result<EvernoteUser>();
            loginResult.Results = repoUser.Find(x => x.UserName == data.Username && x.Password == data.Password);

            if (loginResult.Results != null)
            {
                if (!loginResult.Results.isActive)
                {
                    loginResult.AddError(ErrorMessageCode.UserIsNotActive, "Kullanıcı aktive edilmemiştir.");
                }

            }
            else
            {
                loginResult.AddError(ErrorMessageCode.UsernameOrPasswordWrong, "Kullanıcı ya da Şifre hatalı.");
            }
            return loginResult;

        }

        public Result<EvernoteUser> ActivateUser(Guid activateId)
        {
            Result<EvernoteUser> activateResult = new Result<EvernoteUser>();
            activateResult.Results = repoUser.Find(x => x.ActivateGuid == activateId);
            if (activateResult.Results != null)
            {
                if (activateResult.Results.isActive)
                {
                    activateResult.AddError(ErrorMessageCode.UserAlReadyActive, "Kullanıcı zaten aktive edilmiştir.");
                    return activateResult;
                }
                activateResult.Results.isActive = true;
                repoUser.Update(activateResult.Results);
            }
            else
            {
                activateResult.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirecek kullanıcı bulunamadı.");
            }
            return activateResult;
        }
    }
}
