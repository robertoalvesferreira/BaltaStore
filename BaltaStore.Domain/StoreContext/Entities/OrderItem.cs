﻿using BaltaStore.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            if (product.QuantityOnHand < quantity)
                AddNotification("Quantity", "Produtor fora de estoque");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; private set; }

        public decimal Quantity { get; private set; }
       
        public decimal Price { get; private set; }
    }
}
