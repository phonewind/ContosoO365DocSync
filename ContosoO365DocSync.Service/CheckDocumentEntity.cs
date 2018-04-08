﻿using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContosoO365DocSync.Service
{
    public class CheckDocumentEntity : TableEntity
    {
        public CheckDocumentEntity()
        {
            this.PartitionKey = Guid.NewGuid().ToString();
            this.RowKey = Guid.NewGuid().ToString();
        }

        public string Comments { get; set; }
    }
}
