using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;

namespace election_day.Test;

[Collection("Sequential")]
public class TestThirdReq
{
    [Theory(DisplayName = "Deve imprimir o resultado")]
    [InlineData(new string[]{"6","1","1","5","A","3","2"}, 2, 1, 1, 2)]
    public void TestPrintResult(
        string[] entrys,
        int expectedReceivedOption1,
        int expectedReceivedOption2,
        int expectedReceivedOption3,
        int expectedOptionNull)
    {
        using (StringWriter stringWriter = new())
        {
            string useInStringReader = "";
            foreach (var entry in entrys)
            {
                useInStringReader += entry + "\n";
            }

            using (StringReader stringReader = new(useInStringReader))
            {

                BallotBox instance = new();

                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);


                instance.Start(entrys.Length);

                instance.receivedOption1.Should().Be(expectedReceivedOption1);
                instance.receivedOption2.Should().Be(expectedReceivedOption2);
                instance.receivedOption3.Should().Be(expectedReceivedOption3);
                instance.optionNull.Should().Be(expectedOptionNull);
            }
        }
    }
}