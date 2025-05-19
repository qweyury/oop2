using System;
using System.Diagnostics;
using System.Net;

class Program
{
    static void Main()
    {
        var stopwatch = Stopwatch.StartNew();

        MakeRequest("https://jsonplaceholder.typicode.com/posts/1");
        MakeRequest("https://jsonplaceholder.typicode.com/posts/2");
        MakeRequest("https://jsonplaceholder.typicode.com/posts/3");

        stopwatch.Stop();
        Console.WriteLine($"Total execution time: {stopwatch.ElapsedMilliseconds} ms");
    }

    static void MakeRequest(string url)
    {
        try
        {
            var client = new WebClient();
            string response = client.DownloadString(url);
            Console.WriteLine(response);
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Error accessing {url}: {ex.Message}");
        }
    }
}
