/*using Newtonsoft.Json;*/
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {
        /*HttpClient client = new HttpClient();
        using HttpResponseMessage response = await client.GetAsync("https://localhost:7173/WeatherForecast");
        response.EnsureSuccessStatusCode();
        var responseBody = await response.Content.ReadAsStringAsync();
        var obj = JsonConvert.DeserializeObject<User>(responseBody);

        //WeatherForecast a = JsonUtility.FromJson<WeatherForecast>(responseBody);
        Debug.Log("JSON response1: " + obj.FirstName.ToString());*/
    }
    

    // Update is called once per frame
    

    public class User
    {
        public string FirstName { get; set; }
    }
}
