﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Domain.Exception.CardNumber;

public class CardNumberTooShortException : Exception
{
    public CardNumberTooShortException(string message)
    {
    }
}
