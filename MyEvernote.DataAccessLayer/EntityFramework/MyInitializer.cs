using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyEvernote.Entities;

namespace MyEvernote.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<MyEverNoteDbContext>
    {

        protected override void Seed(MyEverNoteDbContext context)
        {
            EvernoteUser admin = new EvernoteUser()
            {
                Name = "Kerem",
                Surname = "Ermek",
                UserName = "Admin",
                Email = "admin@admin.com",
                Password = "123",
                ImagesFileName = "user-image.jpg",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                isAdmin = true,
                ModifiedUser = "kerem",
                ModifiedOn = DateTime.Now.AddMinutes(10)
            };
            EvernoteUser standartuser = new EvernoteUser()
            {
                Name = "Ali",
                Surname = "Veli",
                UserName = "User",
                Email = "ali@ali.com",
                Password = "1234",
                ImagesFileName = "user-image.jpg",
                ActivateGuid = Guid.NewGuid(),
                isActive = true,
                ModifiedUser = "kerem",
                ModifiedOn = DateTime.Now.AddMinutes(10)
            };

            context.EverNoteUsers.Add(admin);
            context.EverNoteUsers.Add(standartuser);

            for (int i = 0; i < 8; i++)
            {
                EvernoteUser user = new EvernoteUser()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    UserName = $"user{i}",
                    Email = FakeData.NetworkData.GetEmail(),
                    Password = "1234",
                    ImagesFileName = "user-image.jpg",
                    ActivateGuid = Guid.NewGuid(),
                    isActive = true,
                    ModifiedUser = "kerem",
                    ModifiedOn = DateTime.Now.AddMinutes(10)
                };
                context.EverNoteUsers.Add(user);
            }

            context.SaveChanges();

            List<EvernoteUser> userList = context.EverNoteUsers.ToList();
            //Adding fake category
            for (int i = 0; i < 10; i++)
            {

                Category cat = new Category()
                {
                    Title = FakeData.PlaceData.GetStreetName(),
                    Description = FakeData.PlaceData.GetAddress(),
                    ModifiedOn = DateTime.Now.AddMinutes(10),
                    ModifiedUser = "kerem"
                };

                context.Cateories.Add(cat);
                //Adding fake note

                for (int k = 0; k < FakeData.NumberData.GetNumber(5, 10); k++)
                {
                    EvernoteUser owner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                    Note note = new Note()
                    {
                        Title = FakeData.TextData.GetAlphabetical(FakeData.NumberData.GetNumber(5, 15)),
                        Text = FakeData.TextData.GetSentences(FakeData.NumberData.GetNumber(1, 3)),
                        NvgCategory=cat,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        NvgUser = owner,
                        ModifiedOn=FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1),DateTime.Now),
                        ModifiedUser= owner.UserName
                    };

                    cat.NvgNote.Add(note);
                    //Adding fake comments
                    for (int j = 0; j< FakeData.NumberData.GetNumber(3,5); j++)
                    {
                        EvernoteUser commentOwner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        EvernoteComment commnet = new EvernoteComment()
                        {
                            Text = FakeData.TextData.GetSentence(),                            
                            NvgUser= commentOwner,
                            ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                            ModifiedUser = commentOwner.UserName
                            
                        };

                        note.NvgComment.Add(commnet);
                    }

                   
                    for (int m = 0; m < note.LikeCount; m++)
                    {
                        Liked liked = new Liked()
                        {
                            NvgEverUser = userList[m]
                        };
                        note.NvgLiked.Add(liked);
                        
                    }
                }
            }

            context.SaveChanges();
        }
    }
}
