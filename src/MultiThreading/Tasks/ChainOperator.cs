using System.Text.Json;

namespace MultiThreading.Tasks
{
    /// <summary>
    /// Performs multiple chain of asynchronous operations.
    /// </summary>
    internal class ChainOperator
    {
        /// <summary>
        /// Performs multiple asynchronous operations and displays their result.
        /// </summary>
        /// <returns>The task representing the asynchronous operation.</returns>
        public async Task Execute()
        {
            string header = $@"
=====================================
    Multi-layered async/await
=====================================";
            Console.Write(header);

            int result = await this.JsonParserAsync();
            Console.WriteLine($"Result of json parser: {result}");
        }

        private async Task<int> JsonParserAsync()
        {
            Console.WriteLine($"\nJson Parser is initialized");
            string response = await this.ServiceCallAsync();
            JsonDocument json = JsonDocument.Parse(response);

            int id = json.RootElement.GetProperty("id").GetInt32();

            return id;
        }

        private async Task<string> ServiceCallAsync()
        {
            int cpuBoundOperationResult = await this.CPUBoundOperator();
            Console.WriteLine($"\nResult of CPU bound operation: {cpuBoundOperationResult}");

            string link = "https://jsonplaceholder.typicode.com/todos/1";
            using HttpClient client = new HttpClient();
            string data = await client.GetStringAsync(link);

            return data;
        }

        private Task<int> CPUBoundOperator()
        {
            return Task.Run(() =>
            {
                Console.Write($"\nCPU bound Operation is started");
                int sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }

                return sum;
            });
        }
    }
}
