﻿namespace Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string Collection { get; set; }
    }
}