using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTest
    {
        private Document validDocument;

        private Document invalidDocument;

        public DocumentTest()
        {
            validDocument = new Document("28659170377");
            invalidDocument = new Document("1234567");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }    
        
        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
