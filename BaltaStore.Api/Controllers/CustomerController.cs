﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;

        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
      
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommand)_handler.Handle(command);
           
            if (_handler.Invalid)
                return BadRequest(_handler.Notifications); 


            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public Customer Delete()
        {
            return null;
        }
    }
}