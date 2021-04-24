using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DBCrusts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CRUST = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCrusts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBCustomers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBCustomers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBSizes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SIZE = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBStores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STORE = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBStores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBToppings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TOPPING = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBToppings", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DBOrders",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DBStoreID = table.Column<int>(type: "int", nullable: true),
                    DBCustomerID = table.Column<int>(type: "int", nullable: true),
                    PriceTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBOrders_DBCustomers_DBCustomerID",
                        column: x => x.DBCustomerID,
                        principalTable: "DBCustomers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBOrders_DBStores_DBStoreID",
                        column: x => x.DBStoreID,
                        principalTable: "DBStores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBPizzas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PIZZA = table.Column<int>(type: "int", nullable: false),
                    DBCrustID = table.Column<int>(type: "int", nullable: true),
                    DBSizeID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DBOrderID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPizzas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBCrusts_DBCrustID",
                        column: x => x.DBCrustID,
                        principalTable: "DBCrusts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBOrders_DBOrderID",
                        column: x => x.DBOrderID,
                        principalTable: "DBOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DBPizzas_DBSizes_DBSizeID",
                        column: x => x.DBSizeID,
                        principalTable: "DBSizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DBPlacedToppings",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBPlacedToppings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DBPlacedToppings_DBPizzas_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "DBPizzas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DBPlacedToppings_DBToppings_ToppingID",
                        column: x => x.ToppingID,
                        principalTable: "DBToppings",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DBCrusts_CRUST",
                table: "DBCrusts",
                column: "CRUST",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DBCustomers_Name",
                table: "DBCustomers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DBOrders_DBCustomerID",
                table: "DBOrders",
                column: "DBCustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_DBOrders_DBStoreID",
                table: "DBOrders",
                column: "DBStoreID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBCrustID",
                table: "DBPizzas",
                column: "DBCrustID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBOrderID",
                table: "DBPizzas",
                column: "DBOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPizzas_DBSizeID",
                table: "DBPizzas",
                column: "DBSizeID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPlacedToppings_PizzaID",
                table: "DBPlacedToppings",
                column: "PizzaID");

            migrationBuilder.CreateIndex(
                name: "IX_DBPlacedToppings_ToppingID",
                table: "DBPlacedToppings",
                column: "ToppingID");

            migrationBuilder.CreateIndex(
                name: "IX_DBSizes_SIZE",
                table: "DBSizes",
                column: "SIZE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DBStores_Name",
                table: "DBStores",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DBToppings_TOPPING",
                table: "DBToppings",
                column: "TOPPING",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBPlacedToppings");

            migrationBuilder.DropTable(
                name: "DBPizzas");

            migrationBuilder.DropTable(
                name: "DBToppings");

            migrationBuilder.DropTable(
                name: "DBCrusts");

            migrationBuilder.DropTable(
                name: "DBOrders");

            migrationBuilder.DropTable(
                name: "DBSizes");

            migrationBuilder.DropTable(
                name: "DBCustomers");

            migrationBuilder.DropTable(
                name: "DBStores");
        }
    }
}
