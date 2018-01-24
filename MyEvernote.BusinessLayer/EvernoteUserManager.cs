using MyEvernote.BusinessLayer.BaseManager;
using MyEvernote.BusinessLayer.ResultManager;
using MyEvernote.Common.Helpers;
using MyEvernote.DataAccessLayer.EntityFramework;
using MyEvernote.Entities;
using MyEvernote.Entities.Messages;
using MyEvernote.Entities.ValueObjects;
using System;
namespace MyEvernote.BusinessLayer
{
    public class EvernoteUserManager : ManagerBase<EvernoteUser>
    {

        public Result<EvernoteUser> RegisterUser(RegisterViewModel data)
        {
            EvernoteUser user = Find(x => x.UserName == data.Username && x.Email == data.Email);
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
                int dbResult = Insert(new EvernoteUser()
                {
                    Name = data.Name,
                    Surname = data.Surname,
                    UserName = data.Username,
                    ImagesFileName = "user-image.jpg",
                    Email = data.Email,
                    Password = data.Password,
                    ActivateGuid = Guid.NewGuid(),
                    isActive = false

                });
                if (dbResult > 0)
                {
                    rs.Results = Find(x => x.Email == data.Email && x.UserName == data.Username);
                    //Kullanıcı hesabı aktifleştirmek için mail gönderme.
                    string siteUrl = ConfigHelper.Get<string>("SiteRootUrl");
                    string activeUrl = $"{siteUrl}/Register/UserActivate/{rs.Results.ActivateGuid}";
                    string body = $"Merhaba {rs.Results.Name} {rs.Results.Surname};<br><br>Hesabınızı aktifleştirmek için <a href='{activeUrl}' target='_blank'>tıklayınız</a>";
                    MailHelper.SendMail(body, rs.Results.Email, "My Evernote Hesap Aktifleştirme");
                }
            }

            return rs;
        }

        public Result<EvernoteUser> UpdateProfile(EvernoteUser data)
        {
            EvernoteUser user = Find(x => x.ID != data.ID && (x.UserName == data.UserName || x.Email == data.Email) && x.IsDeleted == false);
            Result<EvernoteUser> res = new Result<EvernoteUser>();
            if (user != null && user.ID != data.ID)
            {
                if (user.UserName == data.UserName)
                {
                    res.AddError(ErrorMessageCode.UsernameAlreadyExists, "Kullanıcı Adı Kayıtlı.");
                }
                return res;
            }
            res.Results = Find(x => x.ID == data.ID);
            res.Results.Name = data.Name;
            res.Results.Surname = data.Surname;
            res.Results.AboutUser = data.AboutUser;
            res.Results.UserName = data.UserName;
            res.Results.Password = data.Password;
            res.Results.Email = data.Email;
            if (string.IsNullOrEmpty(data.ImagesFileName) == false)
            {
                res.Results.ImagesFileName = data.ImagesFileName;
            }
            if (Update(res.Results) == 0)
            {
                res.AddError(ErrorMessageCode.ProfileCouldNotUpdate, "Profil Güncellenemedi");
            }
            return res;
        }

        public Result<EvernoteUser> RemoveUserById(int id)
        {
            Result<EvernoteUser> res = new Result<EvernoteUser>();
            EvernoteUser user = Find(x => x.ID == id && x.IsDeleted == false);

            if (user != null)
            {
                if (Delete(user) == 0)
                {
                    res.AddError(ErrorMessageCode.UserCouldNotRemove, "Kullanıcı silinemedi.");
                    return res;
                }
            }
            else
            {
                res.AddError(ErrorMessageCode.UserCouldNotFind, "Kullanıcı bulunamadı.");
            }

            return res;
        }

        public Result<EvernoteUser> GetUserById(int id)
        {
            Result<EvernoteUser> res = new Result<EvernoteUser>();
            res.Results = Find(x => x.ID == id && x.IsDeleted == false);
            if (res.Results == null)
            {
                res.AddError(ErrorMessageCode.UserNotFound, "Kullanıcı bulunamadı");
            }
            return res;
        }

        public Result<EvernoteUser> LoginUser(LoginViewModel data)
        {
            Result<EvernoteUser> loginResult = new Result<EvernoteUser>();
            loginResult.Results = Find(x => x.UserName == data.Username && x.Password == data.Password && x.IsDeleted == false);

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
            activateResult.Results = Find(x => x.ActivateGuid == activateId);
            if (activateResult.Results != null)
            {
                if (activateResult.Results.isActive)
                {
                    activateResult.AddError(ErrorMessageCode.UserAlReadyActive, "Kullanıcı zaten aktive edilmiştir.");
                    return activateResult;
                }
                activateResult.Results.isActive = true;
                Update(activateResult.Results);
            }
            else
            {
                activateResult.AddError(ErrorMessageCode.ActivateIdDoesNotExists, "Aktifleştirecek kullanıcı bulunamadı.");
            }
            return activateResult;
        }
    }
}
