﻿using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        private NpgsqlConnection GetConnectionPostgreSQL()
        {
            return new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<Coupon> GetDiscount(string productName)
        {
            try
            {
                using NpgsqlConnection connection = GetConnectionPostgreSQL();

                Coupon coupon = await connection.QueryFirstAsync<Coupon>("Select * from Coupon Where ProductName = @ProductName", new { ProductName = productName });

                if (coupon == null)
                {
                    return new Coupon
                    {
                        ProductName = "No Discount",
                        Amount = 0,
                        Description = "No discount desc",
                    };
                }
                return coupon;
            }
            catch (Exception ex)
            {

                return new Coupon
                {
                    ProductName = "No Discount",
                    Amount = 0,
                    Description = "No discount desc",
                };
            }
            
        }

        public async Task<bool> CreateDiscount(Coupon coupon)
        {
            using NpgsqlConnection connection = GetConnectionPostgreSQL();

            var affected = await connection.ExecuteAsync("INSERT INTO Coupon (ProductName, Description, Amount)" +
                " VALUES (@ProductName, @Description, @Amount)", new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
                return false;
            
            return true;
        }

        public async Task<bool> UpdateDiscount(Coupon coupon)
        {
            using NpgsqlConnection connection = GetConnectionPostgreSQL();

            var affected = await connection.ExecuteAsync("UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id", new { Id = coupon.Id, ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

            if (affected == 0)
                return false;

            return true;
        }

        public async Task<bool> DeleteDiscount(string productName)
        {
            using NpgsqlConnection connection = GetConnectionPostgreSQL();

            var affected = await connection.ExecuteAsync("DELETE FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

            if (affected == 0)
                return false;

            return true;
        }


    }
}
