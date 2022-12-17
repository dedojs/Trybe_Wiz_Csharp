namespace Animals;


public class Chicken
{
    public Guid Id { get; set; }
    public int EggsPerWeek { get; set; }
    public Chicken? Mother { get; set; }

    public Chicken(int eggsPerWeek, Chicken mother)
    {
        ValidationEggs(eggsPerWeek);
        Id = Guid.NewGuid();
        EggsPerWeek = eggsPerWeek;
        Mother = mother;
    }

    public Chicken(int eggsPerWeek)
    {
        ValidationEggs(eggsPerWeek);
        Id = Guid.NewGuid();
        EggsPerWeek = eggsPerWeek;
    }

    public void ValidationEggs(int eggsPerWeek)
    {
        if (eggsPerWeek < 0)
        {
            throw new ArgumentException("O atributo eggsPerWeek não pode ser menor que ZERO");
        }
    }

}
