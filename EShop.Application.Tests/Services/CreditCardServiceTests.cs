//Historyjka(ang.User story)
//Jako klient chce wprowadzi� m�j numer karty kredytowej. Je�li numer karty jest poprawny, funkcja powinna zwr�ci� informacj� o poprawno�ci oraz wydawce karty.
//Je�li numer karty jest niepoprawny, funkcja powinna zwr�ci� odpowiedni komunikat o b��dzie.

//Kryteria akceptacyjne
//Karta musi mie� od 13 do 19 cyfr (zgodnie ze standardem ISO/IEC 7812).
//System dopuszcza wprowadzenie zar�wno samych cyfry, jak i numeru oddzielonego spacjami oraz my�lnikami.
//System powinien sprawdzi�, czy podany numer karty kredytowej jest poprawny zgodnie z algorytmem Luhna.
//Powinna istnie� mo�liwo�� rozpoznania typu karty na podstawie pierwszych cyfr (np. Visa, Mastercard, American Express).

//MethodName_Scenario_ExpectedBehavior

using EShop.Application.Services;

namespace EShop.Application.Tests.Services;

public class CreditCardServiceTests
{

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
    [InlineData("3497 7965 8312 797")]
    [InlineData("345-470-784-783-010")]
    [InlineData("378523393817437")]
    [InlineData("4024-0071-6540-1778")]
    [InlineData("4532 2080 2150 4434")]
    [InlineData("4532289052809181")]
    [InlineData("5530016454538418")]
    [InlineData("5551561443896215")]
    [InlineData("5131208517986691")]
    public void ValidateCard_WhenGivenTooLongNumber_ReturnsFalse(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var result = creditCardService.ValidateCardNumber(creditCardNumber);

        // Assert
        Assert.False(result);
    }

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
    public void ValidateCard_WhenGivenTooShortNumber_ReturnsFalse(string creditCardNumber)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var result = creditCardService.ValidateCardNumber(creditCardNumber);

        // Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("3497 7965 8312 797", "American Express")]
    [InlineData("345-470-784-783-010", "American Express")]
    [InlineData("378523393817437", "American Express")]
    [InlineData("4024-0071-6540-1778")]
    [InlineData("4532 2080 2150 4434")]
    [InlineData("4532289052809181")]
    [InlineData("5530016454538418")]
    [InlineData("5551561443896215")]
    [InlineData("5131208517986691")]
    public void ValidateCard_WhenGivenCorrectNumber_ReturnsTrue(string creditCardNumber, string expected)
    {
        // Arrange
        var creditCardService = new CreditCardServices();

        // Act
        var result = creditCardService.ValidateCardNumber(creditCardNumber);

        // Assert
        Assert.True(result);
    }
}   