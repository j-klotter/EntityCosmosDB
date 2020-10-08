using Azure.Storage.Blobs;
using EntityFramworkCosmos.Contracts;
using EntityFramworkCosmos.Models;
using EntityFramworkCosmos.Services;
using EntityFramworkCosmos.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.Azure.CosmosRepository;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {

        private readonly MessageService MessageService;
        public MessageController(MessageService messageService)
        {
            this.MessageService = messageService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<Guid>> Download(Guid guid)
        {
            if (guid.IsNull())
            {
                throw new ArgumentNullException("Name is null");
            }


            return null;
        }


        [HttpPost]
        public async Task<Message> Upload([FromBody] MessageDto message)
        {
            if (message.Id.IsNull())
            {
                throw new ArgumentNullException("Guid does not exist");
            }

            var messret = await MessageService.CreateMessageAsync(message);

            return messret;
        }


    }
}
