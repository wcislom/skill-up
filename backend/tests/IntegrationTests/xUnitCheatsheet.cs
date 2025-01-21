namespace IntegrationTests
{
    public class xUnitCheatsheet
    {
        public class FactAndTheoryTests : IDisposable, IClassFixture<SampleFixture>
        {
            private SampleFixture _fixture = null;

            public FactAndTheoryTests(SampleFixture fixture)
            {
                _fixture = fixture;
                Console.WriteLine("Fixture created");
            }

            /* 
             * Facts are useful to test invariant conditions.
             */
            [Fact]
            public void Test1()
            {
                // arrange
                var expected = 4;
                var a = 2;
                var b = 2;

                // act
                var actual = a + b;

                // assert
                Assert.Equal(expected, actual);
            }

            [Theory]
            [InlineData(1)]
            [InlineData(3)]
            public void SampleTheoryTest(int value)
            {
                // act
                var result = IsOdd(value);

                // assert
                Assert.True(result);
            }

            private bool IsOdd(int value) => value % 2 == 1;

            public void Dispose()
            {
             
            }
        }
    }
    
}

public class SampleFixture : IDisposable
{
    private readonly HttpClient _client;
    public SampleFixture()
    {
        _client = new HttpClient();
    }
    public void Dispose()
    {
        _client.Dispose();
    }
}
