using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Source.GoogleApi;
using UnityEngine;

/*

public class TestData : MonoBehaviour
{
    void Start()
    {
        string apiKey = "AIzaSyAdAOk8eI2j4WE2KEXlVTZgdK67HNInZ3c";
        string searchEngineId = "60ff156cb485d45fc";
        string searchQuery = "Home";
        string searchType = "image";
        string searchUrl =
            string.Format(
                "https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}&searchType={3}&imgSize=medium", apiKey,
                searchEngineId, searchQuery, searchType);

        using (WebClient client = new WebClient())
        {
            string response = client.DownloadString(searchUrl);
            Root jsonResponse = JsonConvert.DeserializeObject<Root>(response);
            Debug.Log(jsonResponse.items.Count);


            foreach (var item in jsonResponse.items)
            {
                string imageUrl = item.link;
                Debug.Log(item.link);
            }

            //client.DownloadFile(imageUrl, fileName); сохранение картинки
        }
    }
}

*/
// using System;
// using System.Net.Http;
// using System.Threading.Tasks;
// using Newtonsoft.Json;
// using Unity.VisualScripting;
// using UnityEngine;
//
//
// public class TestData : MonoBehaviour
// {
//     string query = "котики"; // Ваш запрос
//     string apiKey = "your-api-key"; // Ваш ключ API Google
//
//     string cx = "your-cse-id"; // Ваш идентификатор поиска Google
//     
//     public async Task MyMethodAsync()
//     { 
//         using (var httpClient = new HttpClient())
//         {
//             // Формирование запроса
//             var uriBuilder = new UriBuilder($"https://www.googleapis.com/customsearch/v1");
//             var queryParams = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);
//             queryParams["q"] = query;
//             queryParams["cx"] = cx;
//             queryParams["key"] = apiKey;
//             queryParams["searchType"] = "image"; // тип поиска картинок
//             uriBuilder.Query = queryParams.ToString();
//
//             // Выполнение запроса
//             HttpResponseMessage response = await httpClient.GetAsync(uriBuilder.ToString());
//
//             // Получение результата
//             string jsonResult = await response.Content.ReadAsStringAsync();
//             var result = JsonConvert.DeserializeObject(jsonResult);
//
//             // Обработка результата
//             foreach (dynamic item in result.items)
//             {
//                 Debug.Log(item.link);
//             }
//         }
//     }
//
//     void Start()
//     {
//         MyMethodAsync();
//     }
// }