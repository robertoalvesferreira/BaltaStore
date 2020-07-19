using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public Guid Customer { get; set; }

        public IList<OrderItemCommand> OrderItems { get; set; }

        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }
        public bool valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(),36,"Custome", "Identificar do cliente valido")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido")
                );
            return !Invalid;
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }

        public decimal Quantity { get; set; }
    }
}
