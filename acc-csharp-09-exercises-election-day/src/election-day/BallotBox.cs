namespace election_day
{
    public class BallotBox
    {
        public int receivedOption1;
        public int receivedOption2;
        public int receivedOption3;
        public int optionNull;
        
        public int GetCountVoters()
        {   
            int countVoters;
            bool success;
            do
            {
                Console.WriteLine("Informe o número de eleitores:");
                success = int.TryParse(Console.ReadLine(), out countVoters);
                if (countVoters <= 0) Console.WriteLine("Insira um número válido maior que zero");
            }
            while (countVoters <= 0 || !success);
            
            return countVoters;             
        }

        public void Start(int countVoters)
        {
            for (int i = 0; i < countVoters; i += 1)
            {
                Console.WriteLine("Digite o número do candidato de 1 a 3:");
                int result;
                var resultSuccess = int.TryParse(Console.ReadLine(), out result);
                if (!resultSuccess) continue;
                if (result == 1 && resultSuccess) receivedOption1 += 1;
                else if (result == 2 && resultSuccess) receivedOption2 += 1;
                else if (result == 3 && resultSuccess) receivedOption3 += 1;
                else if ( result > 3 || result <= 0 && resultSuccess) optionNull += 1;
            }
            
        }

        public void PrintResult()
        {
            Console.WriteLine("Votação finalizada!!!!");
            Console.WriteLine($"A opção 1 recebeu: {receivedOption1} voto(s)");
            Console.WriteLine($"A opção 2 recebeu: {receivedOption2} voto(s)");
            Console.WriteLine($"A opção 3 recebeu: {receivedOption3} voto(s)");
            Console.WriteLine($"Total de votos anulados: {optionNull} voto(s)");

        }
    }
}
