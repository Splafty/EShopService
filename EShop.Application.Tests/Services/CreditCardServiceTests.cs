//Historyjka(ang.User story)
//Jako klient chce wprowadziæ mój numer karty kredytowej. Jeœli numer karty jest poprawny, funkcja powinna zwróciæ informacjê o poprawnoœci oraz wydawce karty.
//Jeœli numer karty jest niepoprawny, funkcja powinna zwróciæ odpowiedni komunikat o b³êdzie.

//Kryteria akceptacyjne
//Karta musi mieæ od 13 do 19 cyfr (zgodnie ze standardem ISO/IEC 7812).
//System dopuszcza wprowadzenie zarówno samych cyfry, jak i numeru oddzielonego spacjami oraz myœlnikami.
//System powinien sprawdziæ, czy podany numer karty kredytowej jest poprawny zgodnie z algorytmem Luhna.
//Powinna istnieæ mo¿liwoœæ rozpoznania typu karty na podstawie pierwszych cyfr (np. Visa, Mastercard, American Express).

//MethodName_Scenario_ExpectedBehavior

using EShop.Application.Services;
using EShop.Domain.Exceptions.CardNumber;
using System;

namespace EShop.Application.Tests.Services;

public class CreditCardServiceTests
{
    // ---------------------------------------------------------ALL VALID---------------------------------------------------------
    [Theory]
    [InlineData("3497 7965 8312 797")]
    [InlineData("345-470-784-783-010")]
    [InlineData("378523393817437")]
    [InlineData("4024-0071-6540-1778")]
    [InlineData("4532 2080 2150 4434")]
    [InlineData("4532289052809181")]
    [InlineData("5530016454538418")]
    [InlineData("5551561443896215")]
    [InlineData("5131208517986691")]
    public void ValidateCard_WhenGivenCorrectNumber_ReturnsTrue(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var result = creditCardService.ValidateCardNumber(creditCardNumber);

        // Assert
        Assert.True(result);
    }


    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("345-470-784-783-010", "American Express")]
    [InlineData("378523393817437", "American Express")]
    [InlineData("4024-0071-6540-1778", "Visa")]
    [InlineData("4532 2080 2150 4434", "Visa")]
    [InlineData("4532289052809181", "Visa")]
    [InlineData("5530016454538418", "MasterCard")]
    [InlineData("5551561443896215", "MasterCard")]
    [InlineData("5131208517986691", "MasterCard")]
    public void ValidateCard_WhenGivenCorrectName_ReturnsTrue(string creditCardNumber, string expected)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var result = creditCardService.GetCardType(creditCardNumber);

        // Assert
        Assert.Equal(result, expected);
    }
    // ---------------------------------------------------------------------------------------------------------------------------


    // --------------------------------------------------------ALL INVALID--------------------------------------------------------
    [Theory]
    [InlineData("3497 7965 8312 ")]
    [InlineData("345-470-784- 83  ")]
    [InlineData("37")]
    [InlineData("    ")]
    [InlineData("4532 2080 21------")]
    [InlineData("453225280918")]
    [InlineData("553001645453   ")]
    [InlineData("")]
    [InlineData("5")]
    public void ValidateCard_WhenGivenTooShortNumber_ThrowsCardNumberTooShortException(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var exception = Assert.Throws<CardNumberTooShortException>(() => creditCardService.ValidateCardNumber(creditCardNumber));

        // Assert
        Assert.Equal("Credit card number is too short", exception.Message);
    }


    [Theory]
    [InlineData("3497 7965 8312 797 9881 2")]
    [InlineData("345-470-784-783-010  33442")]
    [InlineData("37852339381743798765")]
    [InlineData("4024-0071-6540-1778-9213-2222")]
    [InlineData("4532 2080 2150 4434         11-22-22")]
    [InlineData("4532289052809181 333 - 2222")]
    [InlineData("553001645453841833312")]
    [InlineData("55515614438962153322")]
    [InlineData("5131208517986691456-2- ")]
    public void ValidateCard_WhenGivenTooLongNumber_ThrowsCardNumberTooLongException(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var exception = Assert.Throws<CardNumberTooLongException>(() => creditCardService.ValidateCardNumber(creditCardNumber));

        // Assert
        Assert.Equal("Credit card number is too long", exception.Message);
    }


    [Theory]
    [InlineData("3497 7965 8CA2 797")]
    [InlineData("345-470-7B4-783-010")]
    [InlineData("37DD523393817437")]
    [InlineData("4''4-0071-6540-1778")]
    [InlineData("45*2 2080 2150 4434")]
    [InlineData("45322890__2809181")]
    [InlineData("553[016454538418")]
    [InlineData("5551561==443896215")]
    [InlineData("$$31208517986691")]
    public void ValidateCard_WhenGivenInvalidCharacters_ThrowsCardNumberInvalidException(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var exception = Assert.Throws<CardNumberInvalidException>(() => creditCardService.ValidateCardNumber(creditCardNumber));

        // Assert
        Assert.Equal("Credit card number has invalid characters", exception.Message);
    }
    // -------------------------------------------------------------------------------------------------------------------------------
}