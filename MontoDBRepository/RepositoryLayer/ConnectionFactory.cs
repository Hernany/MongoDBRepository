﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MongoDB.Driver;

namespace ConsoleApp2.RepositoryLayer
{
    public class ConnectionFactory
    {
        private readonly string _connectionString;
        public ConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public IMongoClient GetClient()
        {
            var client = new MongoClient(_connectionString);

            return client;
        }

        public IMongoDatabase GetDataBase(IMongoClient mongoClient, string databaseName)
        {
            var database = mongoClient.GetDatabase(databaseName);

            return database;
        }

        public IMongoDatabase GetDataBase(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);

            return database;
        }

        public IMongoDatabase GetDataBase(string databaseName)
        {
            var client = GetClient();
            var database = client.GetDatabase(databaseName);

            return database;
        }
    }
}
