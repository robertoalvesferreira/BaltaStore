using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Roberto";
            command.LastName = "Alves";
            command.Document = "2865917077";
            command.Email = "roberto@gmail.com";
            command.Phone = "99556575";

            Assert.AreEqual(true, command.valid());
        }
    }
}
