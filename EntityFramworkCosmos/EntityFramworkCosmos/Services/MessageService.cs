using EntityFramworkCosmos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.CosmosRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramworkCosmos.Services
{
    public class MessageService
    {
        readonly IRepository<Message> Repository;

        public MessageService(IRepository<Message> repository)
        {
            this.Repository = repository;
        }

        public async ValueTask<Message> CreateMessageAsync( MessageDto messageDto )
        {
            Message message = await Repository.CreateAsync(new Message
            {
                Id = messageDto.Id,
                BodyId = messageDto.BodyId,
                Type = messageDto.Type,
                Body = new Body
                {
                    ContentId = messageDto.Body.ContentId,
                    Version = messageDto.Body.Version,
                    Message = messageDto.Body.Message
                },
                Header = new Header
                {
                    CaseId = messageDto.Header.CaseId,
                    CaseName = messageDto.Header.CaseName,
                    Receiver = messageDto.Header.Receiver,
                    Sender = messageDto.Header.Sender,
                    TimestampReceive = messageDto.Header.TimestampReceive,
                    TimestampSend = messageDto.Header.TimestampSend,
                    Type = messageDto.Header.Type,
                    RevisionNr = messageDto.Header.RevisionNr,
                }

            }) ;
            return message;
        }

        public async ValueTask ReadMessageAsync(Guid id)
        {
            Message message = await Repository.GetAsync(id.ToString());
        }

        public async ValueTask DeleteSingleMessageAsync(Guid id)
        {
            await Repository.DeleteAsync(id.ToString());
        }
    }
}
