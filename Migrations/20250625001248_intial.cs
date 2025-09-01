using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DarElkotb.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(700)", maxLength: 700, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IconImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2500)", maxLength: 2500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Bio", "Name", "ProfileImage" },
                values: new object[,]
                {
                    { 1, "عالم سعودي وفقيه وأستاذ جامعي.", "محمد بن صالح العثيمين", "othaymeen.jpg" },
                    { 2, "عالم مسلم مجتهد وفقيه ومفسر.", "ابن تيمية", "ibntaymiyyah.jpg" },
                    { 3, "عالم مسلم وفقيه ومفسر.", "ابن القيم الجوزية", "ibnalqayyim.jpg" },
                    { 4, "محدث وفقيه سوري.", "محمد ناصر الدين الألباني", "albani.jpg" },
                    { 5, "عالم سعودي وعضو هيئة كبار العلماء.", "صالح الفوزان", "fawzan.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "فقه" },
                    { 2, "عقيدة" },
                    { 3, "حديث" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Address", "ContactEmail", "Description", "IconImage", "Name" },
                values: new object[,]
                {
                    { 1, "الرياض، السعودية", "info@ibnaljawzi.com", "دار نشر إسلامية سعودية.", "ibnaljawzi.png", "دار ابن الجوزي" },
                    { 2, "القاهرة، مصر", "info@daralsalam.com", "دار نشر إسلامية مصرية.", "daralsalam.png", "دار السلام" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CoverImage", "Description", "Price", "PublishDate", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, "thlathat_osool.jpg", "شرح مبسط لكتاب ثلاثة الأصول.", 35.00m, new DateTime(1995, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "شرح ثلاثة الأصول" },
                    { 2, 2, 2, "wasitiyyah.jpg", "كتاب في العقيدة الإسلامية.", 40.00m, new DateTime(1318, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "العقيدة الواسطية" },
                    { 3, 3, 1, "zad_almaad.jpg", "كتاب في السيرة والفقه.", 55.00m, new DateTime(1350, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "زاد المعاد في هدي خير العباد" },
                    { 4, 4, 3, "salat_alnabi.jpg", "شرح صفة صلاة النبي ﷺ.", 25.00m, new DateTime(1969, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "صفة صلاة النبي" },
                    { 5, 5, 2, "ershad_etiqad.jpg", "كتاب في العقيدة الصحيحة.", 30.00m, new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "الإرشاد إلى صحيح الاعتقاد" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
