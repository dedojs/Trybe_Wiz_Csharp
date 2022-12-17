namespace OddsOrEvens;

public class OddsOrEvens
{
    /// <summary>
    /// This function is to add two numbers
    /// </summary>
    /// <param name="numberOne"> A number to be calculated</param>
    /// <param name="numberTwo"> A number to be calculated</param>
    /// <returns>The sum of the two numbers</returns>
    /// <exception cref="ArgumentOutOfRangeException">If one of the numbers is greater than 10</exception>
    public int SumNumbers(int numberOne, int numberTwo) 
    {
        if (numberOne > 10 || numberOne < 0)
        {
            throw new ArgumentOutOfRangeException("Erro, O número deve ser entre 0 e 10");
        }
        if (numberTwo > 10 || numberTwo < 0)
        {
            throw new ArgumentOutOfRangeException("Erro, O número deve ser entre 0 e 10");
        }

        return numberOne + numberTwo; ;
    }

    /// <summary>
    /// This function is to check if a number is odd or even
    /// </summary>
    /// <param name="resultValue"> The number to be validated</param>
    /// <returns>A string saying whether it's odd or even</returns>
    public string VerifyOddsOrEvens(int resultValue) 
    {
        try
        {
            if (resultValue % 2 == 0)
            {
                return "Par";
            }
            else
            {
                return "Ímpar";
            }
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}
