// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


await foreach (int number in GetNumbersAsync())
{
    WriteLine($"Number: {number}");
}

 static async IAsyncEnumerable<int> GetNumbersAsync()
{
    Random r = Random.Shared;
    // Simulate some work that takes 1.5 to 3 seconds.
    await Task.Delay(r.Next(1500, 3000));
    // Return a random number between 1 and 1000.
    yield return r.Next(1, 1001);
    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(1, 1001);
    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(1, 1001);
}