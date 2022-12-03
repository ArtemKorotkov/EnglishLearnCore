using System.Collections.Generic;

namespace Source
{
    public class RussianLanguage: ILanguage

    {
        private Dictionary<string, string> Phrases;
        public string GetPhrase(string phrase)
        {
            return Phrases[phrase];
        }
        public RussianLanguage()
        {
            this.Phrases = new Dictionary<string, string>();
            this.Phrases.Add("hello","Привет");
            this.Phrases.Add("good","Хороший");
            this.Phrases.Add("Lets training","Начать тренировку");
            this.Phrases.Add("Back to main","Вернуться на главную");
        }

       
       
    }

    
}