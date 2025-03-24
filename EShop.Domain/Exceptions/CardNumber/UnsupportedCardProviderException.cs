using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exceptions.CardNumber;

public class UnsupportedCardProviderException : Exception
{
    public UnsupportedCardProviderException() { }

    public UnsupportedCardProviderException(string message) : base(message) { }

    public UnsupportedCardProviderException(string message, Exception innerException) : base(message, innerException) { }
}
