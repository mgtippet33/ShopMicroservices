﻿using Dapper;
using Discount.Grpc.Entities;
using Npgsql;

namespace Discount.Grpc.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IConfiguration _configuration;

        public DiscountRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<Coupon> GetDiscountAsync(string productName)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString")))
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

                return coupon != null ? coupon : new Coupon();
            }
        }

        public async Task<bool> CreateDiscountAsync(Coupon coupon)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString")))
            {
                var affected = await connection.ExecuteAsync(
                    "INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                    new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

                return affected != 0;
            }
        }

        public async Task<bool> UpdateDiscountAsync(Coupon coupon)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString")))
            {
                var affected = await connection.ExecuteAsync(
                    "UPDATE Coupon SET ProductName = @ProductName, Description = @Description, Amount = @Amount WHERE Id = @Id",
                    new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id });

                return affected != 0;
            }
        }

        public async Task<bool> DeleteDiscountAsync(string productName)
        {
            using (var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString")))
            {
                var affected = await connection.ExecuteAsync(
                    "DELETE FROM Coupon WHERE ProductName = @ProductName",
                    new { ProductName = productName, });

                return affected != 0;
            }
        }
    }
}
