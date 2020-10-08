using EntityFramworkCosmos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateMachineController : ControllerBase
    {
        private readonly MessageDbContext EmailDbContext;

        public StateMachineController(MessageDbContext emailDbContext)
        {
            if( emailDbContext == null)
            {
                throw new ArgumentNullException("Context is null");
            }

            this.EmailDbContext = emailDbContext; 
        }


    }
}
