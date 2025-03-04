namespace Northwind.GraphQL.Service.Queries
{
    public class HelloWorldQuery
    {
        public string GetGreetings() => "Hello, World!";

        public string Farewell() => "Ciao! Ciao!";

        public int RollTheDie() => Random.Shared.Next(1, 7);
    }
}
