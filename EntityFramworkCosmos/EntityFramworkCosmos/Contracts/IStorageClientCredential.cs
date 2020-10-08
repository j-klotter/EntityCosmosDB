using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Contracts
{
   public interface IStorageClientCredential
    {
        string GetStorageAccountName();
        string GetStorageAccountKey();
        string GetStorageConnectionString();
    }
}
