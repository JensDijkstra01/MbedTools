using System.Diagnostics;

namespace MbedTools;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        using HttpClient client = new();
        using HttpRequestMessage request = new(HttpMethod.Post, "http://stable-b.simtocare.local/api/simulator/sim25/power");

        try
        {
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseBody);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}