using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        var stopwatch = Stopwatch.StartNew();

        var task1 = MakeRequestAsync("https://jsonplaceholder.typicode.com/posts/1");
        var task2 = MakeRequestAsync("https://jsonplaceholder.typicode.com/posts/2");
        var task3 = MakeRequestAsync("https://jsonplaceholder.typicode.com/posts/3");

        await Task.WhenAll(task1, task2, task3);

        stopwatch.Stop();
        Console.WriteLine($"Total execution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static async Task MakeRequestAsync(string url)
    {
        try
        {
            using var client = new HttpClient();
            string response = await client.GetStringAsync(url);
            Console.WriteLine(response);
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine($"Error accessing {url}: {ex.Message}");
        }
    }
}
