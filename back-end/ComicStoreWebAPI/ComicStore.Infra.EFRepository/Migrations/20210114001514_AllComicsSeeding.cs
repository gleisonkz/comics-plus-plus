using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicStore.Infra.EFRepository.Migrations
{
    public partial class AllComicsSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2000, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2003, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2005, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2014, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2004, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2015, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2012, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Comic",
                columns: new[] { "ComicID", "Description", "Pages", "Price", "Title", "Year" },
                values: new object[,]
                {
                    { 11, "Marvel is the name of many fictional superheroes appearing in comic books published by Marvel Comics. The character was originally conceived as a female counterpart to Captain Marvel. Like Captain Marvel, most of the bearers of the Ms.", 200, 50f, "Ms. Marvel", 2012 },
                    { 10, "Black Panther is a fictional superhero appearing in American comic books published by Marvel Comics. ... Black Panther's real name is T'Challa, and he is depicted as the king and protector of the fictional African nation of Wakanda.", 258, 85f, "Black Panther", 2016 },
                    { 8, "Captain America is the alter ego of Steve Rogers, a frail young man enhanced to the peak of human perfection by an experimental serum to aid the United States government's efforts in World War II. Near the end of the war, he was trapped in ice and survived in suspended animation until he was revived in modern times.", 136, 86f, "Captain America", 1997 },
                    { 7, "Venom is a fictional character appearing in American comic books published by Marvel Comics, commonly in association with Spider-Man. The character is a sentient alien symbiote with an amorphous, liquid-like form, who survives by bonding with a host, usually human.", 135, 125f, "Venom", 2016 },
                    { 6, "Green Lantern is an ongoing American comic-book series featuring the DC Comics heroes of the same name. ... When the Silver Age Green Lantern, Hal Jordan, was introduced, the character starred in a new volume of Green Lantern starting in 1960.", 105, 77f, "Green Lantern", 2014 },
                    { 5, "Superman is a fictional superhero, who first appeared in American comic books published by DC Comics. ... He was found and adopted by farmers Jonathan and Martha Kent, who named him Clark Kent. Clark developed various superhuman abilities, such as incredible strength and impervious skin.", 67, 35f, "Super Man", 2009 },
                    { 4, "Created as a female counterpart to Superman, Kara Zor-El shares his super powers and vulnerability to Kryptonite. Supergirl plays a supporting role in various DC Comics publications, including Action Comics, Superman, and several comic book series unrelated to Superman.", 85, 66f, "Super Girl", 2005 },
                    { 3, "Iron Man is a fictional superhero appearing in American comic books published by Marvel Comics. ... He uses the suit and successive versions to protect the world as Iron Man. Although at first concealing his true identity, Stark eventually publicly reveals himself to be Iron Man.", 77, 45.99f, "Iron Man", 2002 },
                    { 9, "The character, which is based on the Norse deity of the same name, is the Asgardian god of thunder who possesses the enchanted hammer, Mjolnir, which grants him the ability to fly and manipulate weather amongst his other superhuman attributes.", 158, 55.55f, "Thor", 2012 },
                    { 2, "American teenager Peter Parker, a poor sickly orphan, is bitten by a radioactive spider. As a result of the bite, he gains superhuman strength, speed, and agility along with the ability to cling to walls.", 99, 66.99f, "Spider Man", 1998 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comic",
                keyColumn: "ComicID",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(2019, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(2012, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(2007, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(2000, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(2019, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Author",
                keyColumn: "AuthorID",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(2017, 8, 26, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
