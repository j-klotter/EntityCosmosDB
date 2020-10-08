using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFramworkCosmos.Contracts;
using EntityFramworkCosmos.Models;
using Microsoft.AspNetCore.Mvc;
using Azure.Storage.Blobs;

namespace EntityFramworkCosmos.Services
{
    public class StorageClientService : IAzureStorageClient
    {
        private readonly StorageClientCredentialService StorageClientCredentialService;

        public StorageClientService(StorageClientCredentialService storageClientCredentialService)
        {
            this.StorageClientCredentialService = storageClientCredentialService;
        }
        public Task<Stream> Download(BodyDTO bodydto)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<Guid>> Upload(Stream s)
        {
            BlobServiceClient blobServiceClient = new BlobServiceClient(StorageClientCredentialService.GetStorageConnectionString());
            BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient("myblob");
            Guid guid = Guid.NewGuid();
            BlobClient blobclient = blobContainerClient.GetBlobClient(guid.ToString());
            

            var info = await blobclient.UploadAsync(s);

            return guid;
        }
    }
}
