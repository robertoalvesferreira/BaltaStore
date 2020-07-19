using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Enums;
using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;

        private Product _keyboard;

        private Product _chair;

        private Product _monitor;

        private Customer _customer;

        private Order _order;

        public OrderTests()
        {
            var name = new Name("Roberto", "Alves");
            var document = new Document("11591711657");
            var email = new Email("roberto@gmail.com");
            _customer = new Customer(name, document, email, "553499995565");
            _order = new Order(_customer);
            _mouse = new Product("Mouse Game", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Game", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _chair = new Product("Chair Game", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _monitor = new Product("Monitor Game", "Mouse Gamer", "mouse.jpg", 100M, 10);
        }

        //Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, !_order.Invalid);
        }

        //Ao criar pedido o status deve ser created
        [TestMethod]
        public void SstatusShouldBeCreaatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        //Ao adicionar um novo item, a quantidade deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }


        //Ao adicionar um novo item, deve subtrar a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        //Ao confirmar pedido deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        //Ao pagar um pedido o status deve ser Pago

        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        //Dados 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldTwoWhenPurchasedTenProducts()
        {
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.AddItem(_monitor, 1 );
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        //Ao cancelar o pedido, o statuss deve ser cancelado
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        //Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShppingsWhenOrderCanceled()
        {
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.AddItem(_monitor, 1);
            _order.Ship();
            _order.Cancel();

            foreach(var x in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
           
        }
    }
}
