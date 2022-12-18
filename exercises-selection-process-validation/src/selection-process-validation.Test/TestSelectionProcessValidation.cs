using FluentAssertions;
using Xunit;

namespace SelectionProcessValidation.Test;

public class TestSelectionProcessValidation
{
    [Theory(DisplayName = "Teste de sucesso para validação de processo de seleção")]
    [InlineData("Maria;João;Fernanda;Felipe;Maurício;Mayara", "Maria", true)]
    public void TestSelectionProcessValidationSuccess(string selectedPeople, string name, bool resultExpected)
    {
        var instance = new SelectionProcessValidation();
        instance.ValidateName(selectedPeople, name).Should().Be(resultExpected);
    }

    [Theory(DisplayName = "Teste de exceção para validação de processo de seleção onde nome não pode ser vazio")]
    [InlineData("Maria;João;Fernanda;Felipe;Maurício;Mayara", null)]
    [InlineData(null, "joao")]
    public void TestSelectionProcessValidationException(string selectedPeople, string name)
    {
        var instance = new SelectionProcessValidation();
        Action act = () => instance.ValidateName(selectedPeople, name);
        act.Should().Throw<Exception>().WithMessage("O campo nome está vazio");
    }
}
