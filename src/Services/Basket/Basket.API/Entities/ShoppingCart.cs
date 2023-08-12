﻿namespace Basket.API.Entities
{
    public class ShoppingCart
    {
        public string UserName { get; set; } = string.Empty;

        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();

        public decimal TotalPrice => Items.Sum(x => x.Price * x.Quantity);

        public ShoppingCart()
        {
        }

        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
    }
}
