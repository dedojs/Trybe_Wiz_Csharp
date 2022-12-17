namespace Animals;

public class Cow
{
    public Guid Id { get; set; }
    public int Weight { get; set; }
    public string Breed { get; set; }

    public Cow(int weight, string breed)
    {
        ValidationATT(weight, breed);
        Id = Guid.NewGuid();
        Weight = weight;
        Breed = breed;
    }

    public void ValidationATT(int weight, string breed)
    {
        if (weight <= 0)
        {
            throw new ArgumentException("O peso não pode ser um valor menor que ZERO");
        }
        if (string.IsNullOrEmpty(breed))
        {
            throw new ArgumentException("Raça não pode ser vazio ou nulo");
        }
    }

}