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
                    Name = "deneme",
                    Surname = "deneme",
                    UserName = data.Username,
                    Email = data.Email,
                    Password = data.Password,
                    ModifiedUser = "User6",
                    ActivateGuid = Guid.NewGuid(),
                    isActive = true

                });
                if (dbResult > 0)
                {
                    rs.Results = repoUser.Find(x => x.Email == data.Email && x.UserName == data.Username);
                    //TODO :aktivasyon mail'i göderilecek
                }
            }

            return rs;
        }

        public Result<EvernoteUser> LoginUser(LoginViewModel data)
        {
            Result<EvernoteUser> loginResult = new Result<EvernoteUser>();
            loginResult.Results = repoUser.Find(x => x.UserName == data.Username && x.Password == data.Password);
            
            if (loginResult.Results != null)
            {
                if (!loginResult.Results.isActive)
                {
                    loginResult.AddError(ErrorMessageCode.UserIsNotActive,"Kullanıcı aktive edilmemiştir.");
                }

            }
            else
            {
                loginResult.AddError(ErrorMessageCode.UsernameOrPasswordWrong,"Kullanıcı ya da Şifre hatalı.");
            }
            return loginResult;

        }
    }
}
