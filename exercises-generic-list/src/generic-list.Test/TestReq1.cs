using Xunit;
using FluentAssertions;
using generic_list;
using System;

namespace generic_list.Test;

public class TestReq1
{
    [Theory(DisplayName = "Deve retornar o item correto ao index passado por parâmetro.")]
    [InlineData(new int[]{3, 2, 1}, 0, 3)]
    [InlineData(new int[]{3, 2, 1}, 1, 2)]
    [InlineData(new int[]{3, 2, 1}, 2, 1)]
    [InlineData(new int[]{3, 2, 1, 9, 1}, 3, 9)]
    [InlineData(new int[]{3, 2, 1, 9, 1}, 4, 1)]
    public void TestIndex(int[] list, int entry, int expected)
    {
        GenericList<int> instance = new GenericList<int>();
        for (int i = 0; i < list.Length; i++)
        {
            instance.Add(list[i]);
        }
        list.Should().BeSameAs(list);
        var item = instance.Index(entry);
        item.Should().Be(expected);
    }

    [Theory(DisplayName = "Deve retornar uma exeção quando passado um index maior que o número de elementos da lista")]
    [InlineData(new int[]{3, 2, 1}, 9)]
    [InlineData(new int[]{3, 2, 1}, 100)]
    [InlineData(new int[]{3, 2, 1}, 2000)]
    [InlineData(new int[]{3, 2, 1, 9, 1}, 5)]
    [InlineData(new int[]{3, 2, 1, 9, 1}, 11)]
    public void TestIndexException(int[] list, int entry)
    {
        var instance = new GenericList<int>();

        foreach (var item in list)
        {
            instance.Add(item);
        }

        Action act = () => instance.Index(entry);
        act.Should().Throw<InvalidOperationException>().WithMessage("Não há elementos suficientes na lista");
    }
}