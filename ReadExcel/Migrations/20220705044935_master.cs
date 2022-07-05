using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReadExcel.Migrations
{
    public partial class master : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Master_List",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product_No = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PCAModuleAndInternal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KCC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StandardPackQty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductDescriptione = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitsUPCCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    digitsJANCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RMN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductLabelTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HPInternalPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverpackLabelTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImprintLogo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImprintSerialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BISNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SamePartSNCheck = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierPartNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OptionPN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpareNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CDCLabelTemplate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Master_List", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Master_List");
        }
    }
}
