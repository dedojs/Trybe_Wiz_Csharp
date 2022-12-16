using Xunit;
using System.IO;
using System;
using election_day;
using FluentAssertions;
using Xunit.Sdk;

namespace election_day.Test;

[Collection("Sequential")]
public class TestFirstReq
{
    [Theory(DisplayName = "Deve ler a quantidade de eleitores")]
    [InlineData(1)]
    public void TestGetCountVoters(int countVoters)
    {
        using (var stringWriter = new StringWriter())
        {
            using (var stringReader = new StringReader(countVoters.ToString()))
            {
                if (countVoters <= 0)
                {
                    throw new XunitException();
                }

                BallotBox instance = new();

                Console.SetOut(stringWriter);
                Console.SetIn(stringReader);

                var response = instance.GetCountVoters();

                Console.WriteLine(countVoters);

                response.Should().Be(countVoters);
            }
        }
    }
}
