using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assets.Source.Extension
{
    public static class HttpResponseMessageExtensions
    {
        public async static Task<T> ReadAs<T>(this HttpResponseMessage httpResponseMessage)
        {            
            string content = await httpResponseMessage.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
