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
    public class AttachmentController : ControllerBase
    {
        private readonly MessageDbContext EmailDbContext;

        public AttachmentController(MessageDbContext emailDbContext)
        {
            this.EmailDbContext = emailDbContext;
        }


    }
}
