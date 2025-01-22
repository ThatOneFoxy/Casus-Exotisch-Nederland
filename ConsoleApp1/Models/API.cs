// ======== Imports ========
using System.Net.Http;
using System.Text;
using System.Text.Json;
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
    public async Task<List<string>?> GetDataFromAPI() {
        using (HttpClient client = new HttpClient()) {
            try {
                HttpResponseMessage response = await client.GetAsync(this.apiURL);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var jsonData = JsonSerializer.Deserialize<List<string>>(responseBody);
                return jsonData;
            }
            catch (HttpRequestException e) {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
        return null;
    }

    public async Task PostDataToAPI(List<string> data) {
        using (HttpClient client = new HttpClient()) {
            try {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, this.apiURL);
                request.Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.SendAsync(request);
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