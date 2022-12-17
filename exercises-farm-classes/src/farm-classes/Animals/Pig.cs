namespace Animals;

public class Pig
{
    public Guid Id { get; set; }
    public int Age { get; set; }

    public Pig(int age)
    {
        Id = Guid.NewGuid();
        if (age < 0)
        {
            throw new ArgumentException("Idade não pode ser menor que ZERO");
        }
        Age = age;
    }

}