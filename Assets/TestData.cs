
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using UnityEngine;

    public class Context
    {
        public string title { get; set; }
    }

    public class Image
    {
        public string contextLink { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int byteSize { get; set; }
        public string thumbnailLink { get; set; }
        public int thumbnailHeight { get; set; }
        public int thumbnailWidth { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlSnippet { get; set; }
        public string mime { get; set; }
        public string fileFormat { get; set; }
        public Image image { get; set; }
    }

    public class NextPage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
        public string searchType { get; set; }
    }

    public class Queries
    {
        public List<Request> request { get; set; }
        public List<NextPage> nextPage { get; set; }
    }

    public class Request
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
        public string searchType { get; set; }
    }

    public class Root
    {
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public Context context { get; set; }
        public SearchInformation searchInformation { get; set; }
        public List<Item> items { get; set; }
    }

    public class SearchInformation
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }

    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }



public class TestData : MonoBehaviour
{
    void Start()
    {
        

        string apiKey = "AIzaSyAdAOk8eI2j4WE2KEXlVTZgdK67HNInZ3c";
        string searchEngineId = "60ff156cb485d45fc";
        string searchQuery = "Home";
        string searchType = "image";
        string searchUrl = string.Format("https://www.googleapis.com/customsearch/v1?key={0}&cx={1}&q={2}&searchType={3}&imgSize=medium", apiKey, searchEngineId, searchQuery, searchType);
    
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
