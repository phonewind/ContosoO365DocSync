﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace ContosoO365DocSync.Service
{
    public interface IAzureStorageService
    {
        Task WriteMessageToQueue(string queueMessage, string queueName);
        CloudTable GetTable(string tableName);
    }
}
