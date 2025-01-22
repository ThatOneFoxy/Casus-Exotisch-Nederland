// ======== Imports ========
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1.Models;

public class API {
    // ==== Properties ====.
    private string? apiURL = "";

    // ==== Getters ====
    public string GetAPIURL() {
        return this.apiURL;
    }

    // ==== Methods ====
    public async Task GetDataFromAPI() {
        using (HttpClient client = new HttpClient()) {
            try {
                HttpResponseMessage response = await client.GetAsync(this.apiURL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e) {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }

    // ==== Constructor ====
    public API(string apiURL) {
        this.apiURL = apiURL;
    }
}