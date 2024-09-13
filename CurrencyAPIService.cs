using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CurrencyAPITestMAUI
{
    internal class CurrencyAPIService
    {

        const string baseURL = "https://api.apilayer.com/exchangerates_data/convert";
        HttpClient client = new HttpClient();
        public async Task<CurrencyResponseModel> Convert(float amount, string to, string from = "AUD")

        {
            // Send the request 
            string fullURL = $"{baseURL}?amount ={amount}&from={from}&to={to}";
            HttpRequestMessage message = new(HttpMethod.Get, fullURL);
            message.Headers.Add("apikey", "Nd9qTZSjaLlKNQ30HaG9PVoM99OI29NK");
            var response = await client.SendAsync(message);
            if (!response.IsSuccessStatusCode) throw new HttpResponseException();

            // Response JSON to C# Object
            string responseString = await response.Content.ReadAsStringAsync();
            CurrencyResponseModel? currencyResponseModel = JsonConvert.DeserializeObject<CurrencyResponseModel>(responseString);

            if (currencyResponseModel == null) throw new JsonException("Failed to deserialise the responce object");

            // Return the value from the object
            return currencyResponseModel;
        }


    }
    class HttpResponseException : Exception
    {

    }

    
}
