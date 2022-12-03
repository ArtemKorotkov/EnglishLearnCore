using System.Collections;
using System.Collections.Generic;
using Source;
using UnityEngine;
using UnityEngine.UI;

public class LocalizateTextScreen : MonoBehaviour
{
    //put this script in gameobject, wich containse text
    
    [SerializeField] private string KeyWord;
    
    private Text Text;
    
    private void Start()
    {
        Text = gameObject.GetComponent<Text>();
        Text.text = LocalizationController.Translate(KeyWord);
    }

    
}
