using Microsoft.EntityFrameworkCore.Migrations;

namespace CV.Infrastructure.Database.Migrations
{
    public partial class AddIsCardNumberExistsStorProc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp = @"
                CREATE PROCEDURE [dbo].[IsCardNumberExists]
	                @number nvarchar(16),
					@isExist bit OUTPUT
                AS
	                IF EXISTS(SELECT * FROM [dbo].[Cards] WHERE CardNumber = @number)
		                SELECT @isExist = 1
	                ELSE
		                SELECT @isExist = 0
                RETURN 0";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.IsCardNumberExists");
        }
    }
}
