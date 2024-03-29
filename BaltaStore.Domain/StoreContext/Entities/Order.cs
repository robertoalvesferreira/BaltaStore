﻿using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Shared.Entities;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Entities
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            Customer = customer;        
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }

        public string Number { get; private set; }

        public DateTime CreateDate { get; private set; }

        public EOrderStatus Status { get; private set; }

        public IList<OrderItem> Items => _items.ToArray();

        public IList<Delivery> Deliveries =>  _deliveries.ToArray();

        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto{product.Title} não tem {quantity}");

            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }      
        

        //Criar um pedido
        public void Place() {
            // Gera o número do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            
            //Validar 
            if(_items.Count == 0)
            {
                AddNotification("Order", "Este pedido não possui itens");
            }
         
        }

        //Pagar um Pedido
        public void Pay()
        {
            
            Status = EOrderStatus.Paid;
           
        }

        //Enviar um Pedido
        public void Ship()
        {
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            //Quebra as entragas
            foreach(var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }

            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));

        }

        //Cancelar um Pedido
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x=>x.Cancel());
        }

    }
}
