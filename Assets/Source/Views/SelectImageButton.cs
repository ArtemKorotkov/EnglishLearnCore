using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Source
{
    public class SelectImageButton: MonoBehaviour
    {

        [SerializeField] private RawImage image;

        public void Display(string Url)
        {
            StartCoroutine(DisplayImageFromUrl(image, Url));
        }
        
        private IEnumerator DisplayImageFromUrl(RawImage image, string url)
        {
            WWW www = new WWW(url);

            
            yield return www;
           
            
            if (string.IsNullOrEmpty(www.error))
            {
                Texture2D texture = www.texture;
                image.texture = texture;

                if (texture == null)
                {
                    Debug.Log("Error loading image: " + www.error);
                    Destroy(gameObject);
                }
                
            }
            else
            {
                Debug.Log("Error loading image: " + www.error);
                Destroy(gameObject);
            }
            
            
        }
    }
}