﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BaltaStore.Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public List<Customer> GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
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