using EntityFramworkCosmos.Contracts;
using EntityFramworkCosmos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CaseController : ControllerBase
    {
        private readonly MessageDbContext MessageDbContext;
        private readonly CaseDbContext CaseDbContext;
        private readonly IStorageClientCredential storageClientCredential;
        public CaseController (MessageDbContext emailDbContext, CaseDbContext caseDbContext, IStorageClientCredential storageClient)
        {
            if(emailDbContext == null)
            {
                throw new ArgumentNullException("DbContext is null");
            }
            this.MessageDbContext = emailDbContext;
            this.CaseDbContext = caseDbContext;
            this.storageClientCredential = storageClient;
        }

        [HttpGet("{casename}")]
        public Case Find(Guid guid)
        {
            
            if( guid.IsNull())
            {
                throw new ArgumentException("casetype is null");
            }

            var mail = CaseDbContext.Cases.Where(u => u.Id.Equals(guid) ).FirstOrDefault();
     
            return mail;
        }

        [HttpPost("CreateCase")]
        public async Task Create( [FromBody] Case cases )
        {
            if( cases == null)
            {
                throw new ArgumentNullException("email is null");
            }

            cases.Id = Guid.NewGuid();
            CaseDbContext.Add(cases);
            await CaseDbContext.SaveChangesAsync();
        }

    }
}
