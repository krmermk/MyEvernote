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
                AboutUser = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed interdum dolor at consequat aliquet.Quisque sollicitudin dolor nunc, non imperdiet ex hendrerit sagittis.Maecenas tortor odio,consequat quis vestibulum ut, acinia sed augue.Nam vel metus libero.Nam a condimentum mi, ut elementum felis. Vivamus interdum nibh quam, at accumsan purus placerat imperdiet.Nulla malesuada fringilla ligula,  sed luctus nulla sagittis vitae.Mauris est est, venenatis in nibh sit amet, maximus consequat urna. In vitae mi eget velit condimentum consequat vitae ut erat.Fusce ac metus nec sapien eleifend cursus.Aliquam a arcu libero.Ut sodales nisl ut dolor ultricies, in pulvinar nunc feugiat.  Sed sed pretium risus.Nam at egestas sem.Morbi vulputate tempus laoreet.Proin eu ornare dolor, et posuere urna.Aenean vel aliquet metus, nec dictum arcu.Duis sed posuere eros.Ut elementum magna sed augue condimentum aliquam.Aenean rutrum elementum justo eget semper.Cras tempor malesuada tellus.Lorem ipsum dolor sit amet,  consectetur adipiscing elit.Pellentesque a nulla a lacus dictum commodo at vel tellus.Ut sit amet iaculis tortor.Cras eu felis sit amet ex ultricies finibus.Suspendisse ultrices enim et fermentum rutrum.Nullam convallis velit quis libero volutpat laoreet.Sed sed dapibus nunc, ut bibendum sem.Sed nibh risus, convallis eu aliquam sit amet, fermentum quis nunc.Proin in tempor leo.Praesent id tortor ac ipsum imperdiet rutrum.Integer porta urna sed dui vulputate luctus.Vestibulum ac sem eget massa consectetur egestas quis sed risus.",
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
                AboutUser = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed interdum dolor at consequat aliquet.Quisque sollicitudin dolor nunc, non imperdiet ex hendrerit sagittis.Maecenas tortor odio,consequat quis vestibulum ut, acinia sed augue.Nam vel metus libero.Nam a condimentum mi, ut elementum felis. Vivamus interdum nibh quam, at accumsan purus placerat imperdiet.Nulla malesuada fringilla ligula,  sed luctus nulla sagittis vitae.Mauris est est, venenatis in nibh sit amet, maximus consequat urna. In vitae mi eget velit condimentum consequat vitae ut erat.Fusce ac metus nec sapien eleifend cursus.Aliquam a arcu libero.Ut sodales nisl ut dolor ultricies, in pulvinar nunc feugiat.  Sed sed pretium risus.Nam at egestas sem.Morbi vulputate tempus laoreet.Proin eu ornare dolor, et posuere urna.Aenean vel aliquet metus, nec dictum arcu.Duis sed posuere eros.Ut elementum magna sed augue condimentum aliquam.Aenean rutrum elementum justo eget semper.Cras tempor malesuada tellus.Lorem ipsum dolor sit amet,  consectetur adipiscing elit.Pellentesque a nulla a lacus dictum commodo at vel tellus.Ut sit amet iaculis tortor.Cras eu felis sit amet ex ultricies finibus.Suspendisse ultrices enim et fermentum rutrum.Nullam convallis velit quis libero volutpat laoreet.Sed sed dapibus nunc, ut bibendum sem.Sed nibh risus, convallis eu aliquam sit amet, fermentum quis nunc.Proin in tempor leo.Praesent id tortor ac ipsum imperdiet rutrum.Integer porta urna sed dui vulputate luctus.Vestibulum ac sem eget massa consectetur egestas quis sed risus.",
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
                    AboutUser = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Sed interdum dolor at consequat aliquet.Quisque sollicitudin dolor nunc, non imperdiet ex hendrerit sagittis.Maecenas tortor odio,consequat quis vestibulum ut, acinia sed augue.Nam vel metus libero.Nam a condimentum mi, ut elementum felis. Vivamus interdum nibh quam, at accumsan purus placerat imperdiet.Nulla malesuada fringilla ligula,  sed luctus nulla sagittis vitae.Mauris est est, venenatis in nibh sit amet, maximus consequat urna. In vitae mi eget velit condimentum consequat vitae ut erat.Fusce ac metus nec sapien eleifend cursus.Aliquam a arcu libero.Ut sodales nisl ut dolor ultricies, in pulvinar nunc feugiat.  Sed sed pretium risus.Nam at egestas sem.Morbi vulputate tempus laoreet.Proin eu ornare dolor, et posuere urna.Aenean vel aliquet metus, nec dictum arcu.Duis sed posuere eros.Ut elementum magna sed augue condimentum aliquam.Aenean rutrum elementum justo eget semper.Cras tempor malesuada tellus.Lorem ipsum dolor sit amet,  consectetur adipiscing elit.Pellentesque a nulla a lacus dictum commodo at vel tellus.Ut sit amet iaculis tortor.Cras eu felis sit amet ex ultricies finibus.Suspendisse ultrices enim et fermentum rutrum.Nullam convallis velit quis libero volutpat laoreet.Sed sed dapibus nunc, ut bibendum sem.Sed nibh risus, convallis eu aliquam sit amet, fermentum quis nunc.Proin in tempor leo.Praesent id tortor ac ipsum imperdiet rutrum.Integer porta urna sed dui vulputate luctus.Vestibulum ac sem eget massa consectetur egestas quis sed risus.",
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
                        NvgCategory = cat,
                        LikeCount = FakeData.NumberData.GetNumber(1, 9),
                        NvgUser = owner,
                        ModifiedOn = FakeData.DateTimeData.GetDatetime(DateTime.Now.AddYears(-1), DateTime.Now),
                        ModifiedUser = owner.UserName
                    };

                    cat.NvgNote.Add(note);
                    //Adding fake comments
                    for (int j = 0; j < FakeData.NumberData.GetNumber(3, 5); j++)
                    {
                        EvernoteUser commentOwner = userList[FakeData.NumberData.GetNumber(0, userList.Count - 1)];
                        EvernoteComment commnet = new EvernoteComment()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            NvgUser = commentOwner,
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
