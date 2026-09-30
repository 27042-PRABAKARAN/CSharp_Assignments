namespace MultiThreading.Tasks
{
    /// <summary>
    /// Downloads content from given url
    /// </summary>
    internal class DownloadContent
    {
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// To execute Downloading content process from url
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public async Task Execute()
        {
            string url = "https://example.com";

            Console.WriteLine($"Starting asynchronous download from: {url}...\n");

            try
            {
                string content = await this.DownloadContentAsync(url);

                Console.WriteLine($@"Downloaded Content 
{content}
===========================");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"An error occurred during the download: {e.Message}");
            }
            finally
            {
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Simulates downloading content from a URL asynchronously.
        /// </summary>
        /// <param name="url"> Url from where the content will be downloaded</param>
        /// <returns>
        /// A <see cref="Task"/> representing the asynchronous operation.
        /// </returns>
        public async Task<string> DownloadContentAsync(string url)
        {
            string result = await this._client.GetStringAsync(url);
            return result;
        }
    }
}
