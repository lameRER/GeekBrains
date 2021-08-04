using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace lesson_1
{
    internal static class Program
    {
        private static readonly HttpClient Client = new();
        private const string Url = "https://jsonplaceholder.typicode.com/posts/";
        private const string FileName = "result.txt";
        private const int TaskCount = 10;
        private const int StartId = 4;

        private static async Task Main()
        {
            var tasks = new Task<Post>[TaskCount];
            for (var i = 0; i < TaskCount; i++)
            {
                tasks[i] = GetPostAsync(StartId + i);
            }

            Task.WaitAll(tasks);

            await using var writer = new StreamWriter(FileName, false, Encoding.Default);
            foreach (var task in tasks)
            {
                if (task.Result == null) continue;
                var text = task.Result.ToString();
                await writer.WriteLineAsync(text);
                Console.WriteLine(text);
            }
        }

        private static async Task<Post> GetPostAsync(int id)
        {
            try
            {
                var path = $"{Url}{id}";
                var jsonText = await Client.GetStringAsync(path);

                var post = JsonSerializer.Deserialize<Post>(jsonText, new JsonSerializerOptions {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
                return post;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error id={id}: {ex.Message}");
                return null;
            }
        }
    }
}