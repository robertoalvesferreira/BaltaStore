﻿using BaltaStore.Shared;
using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace BaltaStore.Infra.StoreContext.DataContexts
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public BaltaDataContext()
        {
            Connection = new SqlConnection(Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            //if (Connection.State != Connection.Close)
            Connection.Close();
        }
    }
}
