using Microsoft.AspNetCore.Mvc;
using System.Net;
using EShop.Application.Services;
using EShop.Domain.Exceptions.CardNumber;

namespace EShopService.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CreditCardController : ControllerBase
{
    private readonly ICreditCardServices _creditCardServices;

    public CreditCardController(ICreditCardServices creditCardServices)
    {
        _creditCardServices = creditCardServices;
    }


    [HttpGet("validate")]
    public IActionResult ValidateCard([FromQuery] string cardNumber)
    {
        try
        {
            bool isValid = _creditCardServices.ValidateCardNumber(cardNumber);
            string provider = _creditCardServices.GetCardType(cardNumber);
            return Ok(new { IsValid = isValid, Provider = provider });
        }
        catch (CardNumberTooLongException)
        {
            return StatusCode(414, new { error = "Credit card number is too long" });
        }
        catch (CardNumberTooShortException)
        {
            return BadRequest(new { error = "Credit card number is too short" });
        }
        catch (CardNumberInvalidException)
        {
            return BadRequest(new { error = "Credit card number is invalid" });
        }
        catch (UnsupportedCardProviderException)
        {
            return StatusCode(406, new { error = "Unsupported card provider" });
        }
    }
}
