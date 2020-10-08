using EntityFramworkCosmos.Contracts;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Services
{
    public class StorageClientCredentialService : IStorageClientCredential
    {
        private readonly IConfiguration Configuration;


        public StorageClientCredentialService( IConfiguration configuration )
        {
            this.Configuration = configuration;
        }
        public string GetStorageAccountKey()
        {
            return Configuration.GetValue<string>("Storage:AccountKey");
        }

        public string GetStorageAccountName()
        {
            return Configuration.GetValue<string>("Storage:AccountName");
        }

        public string GetStorageConnectionString()
        {
            return Configuration.GetValue<string>("Storage:ConnectionString");
        }
    }
}
