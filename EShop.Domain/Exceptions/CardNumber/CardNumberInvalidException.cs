using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions.CardNumber;

public class CardNumberInvalidException : Exception
{
    public CardNumberInvalidException(string message)
    {
    }
}