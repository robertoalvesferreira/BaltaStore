using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool valid()
        {
            AddNotifications(new ValidationContract()
              .Requires()
              .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter pelo menos 3 caracteres")
              .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
              .HasMinLen(LastName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
              .HasMaxLen(LastName, 40, "LastName", "O nome deve conter pelo menos 3 caracteres")
              .IsEmail(Email, "Email", "O E-mail é invalido")
              );

            return !Invalid;
        }
    }
}
