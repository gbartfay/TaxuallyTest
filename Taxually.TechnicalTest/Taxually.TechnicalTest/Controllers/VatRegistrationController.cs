using Microsoft.AspNetCore.Mvc;
using Taxually.TechnicalTest.Contract;
using Taxually.TechnicalTest.Components.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Taxually.TechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatRegistrationController : ControllerBase
    {
        private readonly IVatRegistrationService _vatRegistrationService;
        
        public VatRegistrationController(IVatRegistrationService vatRegistrationService)
        {
            _vatRegistrationService = vatRegistrationService;
        }
        
        /// <summary>
        /// Registers a company for a VAT number in a given country
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VatRegistrationRequest request)
        {
            switch (request.Country)
            {
                case "GB":
                    // UK has an API to register for a VAT number
                    await _vatRegistrationService.PostAsync(request);
                    break;
                case "FR":
                    // France requires an excel spreadsheet to be uploaded to register for a VAT number
                    await _vatRegistrationService.EnqueueCsvAsync(request.CompanyName, request.CompanyId);
                    break;
                case "DE":
                    // Germany requires an XML document to be uploaded to register for a VAT number
                    await _vatRegistrationService.EnqueueXmlAsync(request);
                    break;
                default:
                    throw new Exception("Country not supported");

            }
            return Ok();
        }
    }
}
