﻿using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Models
{
    public class Message : Item
    {
        public Guid Id { get; set; }
        public Guid BodyId { get; set; }
        public Header Header { get; set; }
        public Body Body { get; set; }
        public string PartitionKey { get; set; }

    }
}
