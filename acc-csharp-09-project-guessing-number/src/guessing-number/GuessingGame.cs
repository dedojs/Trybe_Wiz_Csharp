using System;

namespace guessing_number;

public class GuessNumber
{    
    private IRandomGenerator random;    
    public GuessNumber() : this(new DefaultRandom()){}
    public GuessNumber(IRandomGenerator obj)
    {
        this.random = obj;
    }

    //user variables
    public string? response;
    public int userValue;
    public int randomValue;

    public void Greet()
    {   
        Console.WriteLine("---Bem-vindo ao Guessing Game---");
        Console.WriteLine("Para começar, tente adivinhar o número que eu pensei, entre -100 e 100!");
    }

    public void ChooseNumber()
    {   
        bool responseSuccess;
        int number;
        do
        {
            responseSuccess = int.TryParse(Console.ReadLine(), out number);
            if (!responseSuccess || number < -100 || number > 100) Console.WriteLine("Por favor, digite um número inteiro:");
        } while (!responseSuccess || number < -100 || number > 100);
        userValue = Convert.ToInt32(number);
    }
    
    public void RandomNumber()
    {
        randomValue = random.GetInt(-100, 100);
        // Console.WriteLine("random " + randomValue);
    }
    
    public void AnalyzePlay()
    {
        if (userValue > randomValue) Console.WriteLine("Tente um número MENOR");
        else if (userValue < randomValue) Console.WriteLine("Tente um número MAIOR");
        else Console.WriteLine("ACERTOU!");
    }
}