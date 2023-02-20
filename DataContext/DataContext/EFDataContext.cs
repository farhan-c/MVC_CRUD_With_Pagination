using DataContext.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataContext.DataContext
{
    public class EFDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:basiccrud.database.windows.net,1433;Initial Catalog=product;Persist Security Info=False;User ID=basicadmin;Password=Passw0rd@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        public Product GetProductById(int ProductId)
        {
            //IQueryable<Product> data = this.Products.FromSqlRaw(
            //    "Exec [dbo].uspGetProduct @p_ProductId ", new SqlParameter("p_ProductId", ProductId));
            
            var data = this.Products
                            .FromSqlRaw(@"exec [dbo].uspGetProduct @p_ProductId", new SqlParameter("p_ProductId", ProductId)).ToList();

            if (data != null)
                return data.FirstOrDefault();
            else
                return new Product();
        }

    }
}