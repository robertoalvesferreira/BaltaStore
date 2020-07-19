using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, 
        ICommandHandler<CreateCustomerCommand>, 
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o cpf ja existe na base
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF ja esta em uso");

            //Verificar se o email ja existe na base
            if (_repository.CheckEmail(command.Email))
                AddNotification("Document", "Este CPF ja esta em uso");
            
            //Criar os VOs

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            //Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);
            //validar entidades e vos
            //AddNotifications(name.Notifications);
            //AddNotifications(document.Notifications);
            //AddNotifications(email.Notifications);
            //AddNotifications(customer.Notifications);

            if (Invalid)
                return null;
            //Persistir o cliente
            _repository.Save(customer);

            //Enviar um e-mail de boas vindas
            _emailService.Send(email.Address, "roberto@gmail.com", "Bem vindo", "Seja nem vindo");
            
            //Retornar o resultado para tela
            return new CreateCustomerCommandResult(customer.Id, name.ToString(),email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
