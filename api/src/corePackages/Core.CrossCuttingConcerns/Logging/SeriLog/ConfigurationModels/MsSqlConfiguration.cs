﻿namespace Core.CrossCuttingConcerns.Logging.SeriLog.ConfigurationModels
{
    public class MsSqlConfiguration
    {
        public string ConnectionString { get; set; }
        public string TableName { get; set; }
        public bool AutoCreateSqlTable { get; set; }
    }
}