namespace trybank;

public class Trybank
{
    public bool Logged;
    public int loggedUser;
    
    //0 -> Número da conta
    //1 -> Agência
    //2 -> Senha
    //3 -> Saldo
    public int[,] Bank;
    public int registeredAccounts;
    private int maxAccounts = 50;
    public Trybank()
    {
        loggedUser = -99;
        registeredAccounts = 0;
        Logged = false;
        Bank = new int[maxAccounts, 4];
    }

    public void RegisterAccount(int number, int agency, int pass)
    {
        try
        {
            for(int index = 0; index <= registeredAccounts; index += 1)
            {
                if (number == Bank[index, 0] && agency == Bank[index, 1])
                {
                    throw new ArgumentException("A conta já está sendo usada!");
                }
            }
            Bank[registeredAccounts, 0] = number;
            Bank[registeredAccounts, 1] = agency;
            Bank[registeredAccounts, 2] = pass;
            Bank[registeredAccounts, 3] = 0;
            registeredAccounts += 1;
        } catch (ArgumentException error) {
            Console.WriteLine(error.Message);
            throw error;
        }
    }

    public void Login(int number, int agency, int pass)
    {
        try
        {
            if (Logged) throw new AccessViolationException("Usuário já está logado");

            for(int index = 0; index <= registeredAccounts; index += 1)
            {
                if (number == Bank[index, 0] && agency == Bank[index, 1] && pass == Bank[index, 2])
                {
                    loggedUser = index;
                    Logged = true;
                }
                else if (number == Bank[index, 0] && agency == Bank[index, 1] && pass != Bank[index, 2])
                {
                    throw new ArgumentException("Senha incorreta");
                }
            }

            if (!Logged && loggedUser == -99) throw new ArgumentException("Agência + Conta não encontrada");


        } catch (AccessViolationException error)
        {   
            Console.WriteLine(error.Message);
            throw error;
        } catch (ArgumentException error)
        {   
            Console.WriteLine(error.Message);
            throw error;
        }
    }

    public void Logout()
    {
        try
        {
            if (!Logged) throw new AccessViolationException("Usuário não está logado");

            Logged = false;
            loggedUser = -99;

        } catch (AccessViolationException error)
        {
            Console.WriteLine(error.Message);
            throw error;
        }
    }

    public int CheckBalance()
    {
        try
        {
            if (!Logged) throw new AccessViolationException("Usuário não está logado");
            return Bank[loggedUser, 3];

        } catch (AccessViolationException error)
        {
            Console.WriteLine(error);
            throw error;
        }
    }

    public void Transfer(int destinationNumber, int destinationAgency, int value)
    {
        try
        {
            if (!Logged) throw new AccessViolationException("Usuário não está logado");
            if (Bank[loggedUser, 3] < value) throw new InvalidOperationException("Saldo insuficiente");
            
            for (int index = 0; index <= registeredAccounts; index += 1) 
            {
                if (Bank[index, 0] == destinationNumber && Bank[index, 1] == destinationAgency)
                {
                    Bank[index, 3] += value;
                    Bank[loggedUser, 3] -= value;
                } else if (index == registeredAccounts -1)
                {
                    throw new ArgumentException("Agência + Conta não encontrada");
                }
                
            }

        } catch (AccessViolationException error)
        {
            Console.WriteLine(error);
            throw error;
        } catch (InvalidOperationException error)
        {
            Console.WriteLine(error);
            throw error;
        }
        catch (ArgumentException error)
        {
            Console.WriteLine(error);
            throw error;
        }
    }

    public void Deposit(int value)
    {
        try
        {
            if (!Logged) throw new AccessViolationException("Usuário não está logado");
            Bank[loggedUser, 3] += value;

        } catch (AccessViolationException error)
        {
            Console.WriteLine(error);
            throw error;
        }
    }

    public void Withdraw(int value)
    {
        try
        {
            if (!Logged) throw new AccessViolationException("Usuário não está logado");
            if (Bank[loggedUser, 3] < value)
            {
                throw new InvalidOperationException("Saldo insuficiente");
            }
                Bank[loggedUser, 3] -= value;

        } catch (AccessViolationException error)
        {
            Console.WriteLine(error);
            throw error;
        } catch (InvalidOperationException error)
        {
            Console.WriteLine(error);
            throw error;
        }
    }
}
