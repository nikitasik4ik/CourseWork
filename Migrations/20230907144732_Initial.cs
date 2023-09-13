using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseWork.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName_Client = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    LastName_Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronomyk_Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateBirth = table.Column<DateTime>(type: "date", nullable: true),
                    Phone_Client = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Country = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Post = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.PostID);
                });

            migrationBuilder.CreateTable(
                name: "product_t",
                columns: table => new
                {
                    TypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Type = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_t", x => x.TypeID);
                });

            migrationBuilder.CreateTable(
                name: "provider",
                columns: table => new
                {
                    ProviderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name_Provider = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    CountryID = table.Column<int>(type: "int", nullable: true),
                    Phone_Provider = table.Column<int>(type: "int", nullable: true),
                    Email_Provider = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_provider", x => x.ProviderID);
                    table.ForeignKey(
                        name: "FK_provider_Country",
                        column: x => x.CountryID,
                        principalTable: "Country",
                        principalColumn: "CountryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stuff",
                columns: table => new
                {
                    StuffID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullNameStuff = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    PostID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stuff", x => x.StuffID);
                    table.ForeignKey(
                        name: "FK_stuff_posts",
                        column: x => x.PostID,
                        principalTable: "posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_v",
                columns: table => new
                {
                    ViewID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID = table.Column<int>(type: "int", nullable: true),
                    Name_View = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_v", x => x.ViewID);
                    table.ForeignKey(
                        name: "FK_product_v_product_t",
                        column: x => x.TypeID,
                        principalTable: "product_t",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true, collation: "SQL_Latin1_General_CP1_CI_AS"),
                    ViewID = table.Column<int>(type: "int", nullable: true),
                    ProviderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_product_v",
                        column: x => x.ViewID,
                        principalTable: "product_v",
                        principalColumn: "ViewID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_products_provider",
                        column: x => x.ProviderID,
                        principalTable: "provider",
                        principalColumn: "ProviderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sales",
                columns: table => new
                {
                    SaleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    Date_Sale = table.Column<DateTime>(type: "date", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    StuffID = table.Column<int>(type: "int", nullable: true),
                    ClientID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sales", x => x.SaleID);
                    table.ForeignKey(
                        name: "FK_sales_clients",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_products",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_sales_stuff",
                        column: x => x.StuffID,
                        principalTable: "stuff",
                        principalColumn: "StuffID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_v_TypeID",
                table: "product_v",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProviderID",
                table: "products",
                column: "ProviderID");

            migrationBuilder.CreateIndex(
                name: "IX_products_ViewID",
                table: "products",
                column: "ViewID");

            migrationBuilder.CreateIndex(
                name: "IX_provider_CountryID",
                table: "provider",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ClientID",
                table: "sales",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_sales_ProductID",
                table: "sales",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_sales_StuffID",
                table: "sales",
                column: "StuffID");

            migrationBuilder.CreateIndex(
                name: "IX_stuff_PostID",
                table: "stuff",
                column: "PostID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sales");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "stuff");

            migrationBuilder.DropTable(
                name: "product_v");

            migrationBuilder.DropTable(
                name: "provider");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "product_t");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
