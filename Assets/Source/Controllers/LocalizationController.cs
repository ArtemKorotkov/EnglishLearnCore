using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;


namespace Source
{
    public class LocalizationController: IController

    {
        
        private EnglishLanguage English = new EnglishLanguage();
        private RussianLanguage Russian = new RussianLanguage();

        private static ILanguage Language;


        public void Init()
        { 
            Language = Russian;
        }

        public void Run()
        {
            
        }

        public static String Translate(string Phrase)
        {
            return Language.GetPhrase(Phrase);
        }

    }
}