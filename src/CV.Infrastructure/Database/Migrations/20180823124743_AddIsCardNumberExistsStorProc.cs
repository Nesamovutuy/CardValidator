using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Infrastructure.Database.Migrations
{
    public partial class AddIsCardNumberExistsStorProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"
                CREATE PROCEDURE [dbo].[IsCardNumberExists]
	                @number nvarchar(16)
                AS
	                IF EXISTS(SELECT * FROM [dbo].[Cards] WHERE CardNumber = @number)
		                SELECT 1
	                ELSE
		                SELECT 0
                GO";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.IsCardNumberExists");
        }
    }
}
