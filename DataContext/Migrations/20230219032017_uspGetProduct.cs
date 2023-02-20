using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataContext.Migrations
{
    /// <inheritdoc />
    public partial class uspGetProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"Create procedure uspGetProduct
(  
    @p_ProductId   INT = 0  
)  
As  
BEGIN  
    IF @p_ProductId > 0  
    BEGIN  
        Select * from DBO.Product WHERE ProductId= @p_ProductId  
    END  
  
END  
GO  ";
            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
