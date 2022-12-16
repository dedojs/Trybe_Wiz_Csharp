namespace BiggestNumber;
public class BiggestNumber
{
    /// <summary>
    /// Esta função avalia os três números passados como entrada e retorna o maior deles.
    /// </summary>
    /// <param name="first"> Um número inteiro </param>
    /// <param name="second">Um número inteiro </param>
    /// <param name="third">Um número inteiro </param>
    /// <returns> O maior valor dentre os passados como parâmetro de entrada.</returns>
    public static int IdentifyBiggestNumber(int first, int second, int third)
    {
        var biggest = first;

        if (first > second && first > third) biggest = first;
        else if (second > first && second > third) biggest = second;
        else biggest = third;

        // Console.WriteLine($"O maior número é { biggest }");
        return biggest;
    }
}