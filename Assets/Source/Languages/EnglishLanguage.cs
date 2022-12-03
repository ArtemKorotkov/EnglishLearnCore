using System.Collections.Generic;

namespace Source
{
    public class EnglishLanguage: ILanguage

    {
        private Dictionary<string, string> Phrases;
        public EnglishLanguage()
        {
            Phrases = new Dictionary<string, string>();
            this.Phrases.Add("hello","hello");
            this.Phrases.Add("good","good");
            this.Phrases.Add("Lets training","Lets training");
            this.Phrases.Add("Back to main","Back to main");
        }

       
        public string GetPhrase(string phrase)
        {
            return Phrases[phrase];
        }
    }
}