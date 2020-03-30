using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();
            command.FirstName = "Rodrigo";
            command.LastName = "Lima";
            command.Document = "99999999999";
            command.Email = "email@email.com";
            command.BarCode = "1234578";
            command.BoletoNumber = "4654654564";
            command.PaymentNumber = "46464";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "RRL";
            command.PayerDocument = "45468454";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "payer@email.com";
            command.Street = "Rua 1";
            command.Number = "123";
            command.Neighborhood = "Bairro 1";
            command.City = "Cidade";
            command.State = "Estado";
            command.Country = "País";
            command.ZipCode = "123456";
            
            handler.Handle(command);

            Assert.AreEqual(false, handler.Valid);
        }
    }
}