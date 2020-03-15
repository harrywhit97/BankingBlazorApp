using CsvReader;
using Domain.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BankingCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors()]
    public class UploadController : ControllerBase
    {
        [HttpPost("files"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            foreach (var file in files)
            {
                List<Transaction> transactions = new List<Transaction>();
                using (var stream = file.OpenReadStream())
                {
                    transactions.AddRange(CsvReader.Reader.ReadFileStream(stream));                      
                }
            }

            return Ok();
        }
    }
}
