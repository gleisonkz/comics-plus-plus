using ComicStore.Domain.POCO;
using ComicStore.Shared.Classes;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class SeedImages : Migration
    {
        protected override async void Up(MigrationBuilder migrationBuilder)
        {
            // var imagesInfo = new List<string>
            // {
            //     @"ComicStoreWebAPI/Images/hulk.jpg",
            //     @"Images/amazing-spider-man.jpg",
            //     @"Images/the-invencible-iron-man.jpg",
            //     @"Images/super-girl.jpg",
            //     @"Images/green-lantern.jpg",
            //     @"Images/venom.jpg",
            //     @"Images/captain-america.jpg",
            //     @"Images/thor.jpg",
            //     @"Images/black-panther.jpg",
            //     @"Images/ms-marvel.jpg",
            // };

            //var imagesUrl = new List<string>
            // {
            //     //@"https://drive.google.com/file/d/19n-fLXXLUBCdldn_81Cij7ufZ_ZLDyRO/view?usp=sharing",
            //     //@"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            //     @"https://drive.google.com/drive/folders/1LC8jkznRM2tswlmk-bI8EQsZxzL2e_hI",
            // };

            var images = new List<ComicImage>
            {
                new ComicImage
                {
                    ComicID = 1,
                    Name = "hulk",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/19n-fLXXLUBCdldn_81Cij7ufZ_ZLDyRO/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 2,
                    Name = "amazing-spider-man",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1SYdELoeBGQOoA_OEcsWEJIq0lqGffnAx/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 3,
                    Name = "the-invencible-iron-man",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1zcmCy1Ee3F_gTgermfmthS45XPOGnluS/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 4,
                    Name = "super-girl",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1muFlSCZA8iMVR5AtVYlHXV4qa9VrDlxE/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 5,
                    Name = "green-lantern",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1NNnWo5pELN1TJ7O2VudwG3ZYKZJA1e_k/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 6,
                    Name = "venom",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1gchPyg5hqpHnjHWKf9HDZGhFzf5HFL70/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 7,
                    Name = "captain-america",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1l4wn_3XHeb2jK35vtG6wjAzgcT4kwPP7/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 8,
                    Name = "thor",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1pXTlK79Q2eOHSHM8pWevvVfgaEYGfwzW/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 9,
                    Name = "black-panther",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/13YaTCRhx7baewUwTA5FTcqaFl154uS5T/view?usp=sharing")
                },
                new ComicImage
                {
                    ComicID = 10,
                    Name = "ms-marvel",
                    Extension = "jpg",
                    Base64 = await Utils.GetImageBytesFromUrl("https://drive.google.com/file/d/1CXsCyou5diLSe7_adc1qUV2qnYQCWV9W/view?usp=sharing")
                },
            };

            // var comicImages = imagesInfo.Select((path, index) =>
            //     new
            //     {
            //         ComicID = index + 1,
            //         Base64 = File.ReadAllBytes(path),
            //         Extension = path.Split('.').Last(),
            //         Name = path.Split('.').First().Split('\\').Last()
            //     }).ToList();

            images.ForEach(image =>
            {
                migrationBuilder.InsertData(
                    table: "ComicImage",
                    columns: new[] { "ComicID", "Base64", "Extension", "Name" },
                    values: new object[,] {
                         {
                             image.ComicID,
                             image.Base64,
                             image.Extension,
                             image.Name
                         }
                    });
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
