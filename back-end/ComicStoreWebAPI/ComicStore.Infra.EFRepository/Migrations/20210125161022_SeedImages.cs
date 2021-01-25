using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class SeedImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var imagesInfo = new List<string>
            {
                @"Resources\hulk.jpg",
                @"Resources\amazing-spider-man.jpg",
                @"Resources\the-invencible-iron-man.jpg",
                @"Resources\super-girl.jpg",
                @"Resources\green-lantern.jpg",
                @"Resources\venom.jpg",
                @"Resources\captain-america.jpg",
                @"Resources\thor.jpg",
                @"Resources\black-panther.jpg",
                @"Resources\ms-marvel.jpg",
            };

            var comicImages = imagesInfo.Select((path, index) =>
                new
                {
                    ComicID = index + 1,
                    Base64 = File.ReadAllBytes(path),
                    Extension = path.Split('.').Last(),
                    Name = path.Split('.').First().Split('\\').Last()
                }).ToList();

            comicImages.ForEach(image =>
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
