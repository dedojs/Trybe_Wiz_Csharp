using Xunit;
using FluentAssertions;
using trybank;
using System;

namespace trybank.Test;

public class TestSecondReq
{
    [Theory(DisplayName = "Deve logar em uma conta!")]
    [InlineData(2, 3, 123)]
    public void TestLoginSucess(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        bank.Login(number, agency, pass);

        bank.Logged.Should().BeTrue();
    }

    [Theory(DisplayName = "Deve retornar exceção ao tentar logar em conta já logada")]
    [InlineData(2, 3, 123)]
    public void TestLoginExceptionLogged(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        bank.Login(number, agency, pass);

        Action action = () => bank.Login(number, agency, pass);
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário já está logado");
    }

    [Theory(DisplayName = "Deve retornar exceção ao errar a senha")]
    [InlineData(1, 2, 123)]
    public void TestLoginExceptionWrongPass(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        var passError = 171;

        Action action = () => bank.Login(number, agency, passError);
        action.Should().Throw<ArgumentException>().WithMessage("Senha incorreta");
    }

    [Theory(DisplayName = "Deve retornar exceção ao digitar conta que não existe")]
    [InlineData(7, 8, 123)]
    public void TestLoginExceptionNotFounded(int number, int agency, int pass)
    {        
        Trybank bank = new();

        Action action = () => bank.Login(number, agency, pass);
        action.Should().Throw<ArgumentException>().WithMessage("Agência + Conta não encontrada");
    }

    [Theory(DisplayName = "Deve sair de uma conta!")]
    [InlineData(1, 2, 123)]
    public void TestLogoutSucess(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        bank.Login(number, agency, pass);
        bank.Logout();

        bank.Logged.Should().BeFalse();
    }

    [Theory(DisplayName = "Deve retornar exceção ao sair quando não está logado")]
    [InlineData(1, 2, 123)]
    public void TestLogoutExceptionNotLogged(int number, int agency, int pass)
    {        
        Trybank bank = new();
        bank.RegisterAccount(number, agency, pass);
        
        Action action = () => bank.Logout();
        action.Should().Throw<AccessViolationException>().WithMessage("Usuário não está logado");
    }

}
