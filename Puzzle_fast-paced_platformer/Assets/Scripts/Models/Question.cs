using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Models
{
    public class Question
    {
        public List<QuestionObject> Questions { get; set; }
        public Question() //"inicializace"
        {
            Questions = new List<QuestionObject>();
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká vlajka?", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "3 + 3?", ChoiceA = "5", ChoiceB = "7?", ChoiceC = "9", ChoiceD = "6", CorrectChoice = "6" });
            Questions.Add(new QuestionObject { QuestionText = "Kdo je nejvyšší?", ChoiceA = "Lenovo", ChoiceB = "HP", ChoiceC = "Mount Everest", ChoiceD = "Xiaomi", CorrectChoice = "Mount Everest" });
            Questions.Add(new QuestionObject { QuestionText = "Kdo je největší výrobce počítačů?", ChoiceA = "Dell", ChoiceB = "Lenovo", ChoiceC = "Xiaomi", ChoiceD = "Samsung", CorrectChoice = "Mount Everest" });
            Questions.Add(new QuestionObject { QuestionText = "Dostaneme jedničku?", ChoiceA = "Ano", ChoiceB = "Ano", ChoiceC = "Ano", ChoiceD = "Ne", CorrectChoice = "Ano" });
            Questions.Add(new QuestionObject { QuestionText = "Kdo si zahrál na nejnovějšího Jamese Bonda?", ChoiceA = "Sean Connery", ChoiceB = "Roger Moore", ChoiceC = "Timothy Dalton", ChoiceD = "Daniel Craig", CorrectChoice = "Daniel Craig" });
            Questions.Add(new QuestionObject { QuestionText = "Jaký je nejnovější .NET?", ChoiceA = "3.2", ChoiceB = "4.2", ChoiceC = "5.0", ChoiceD = "6.0", CorrectChoice = "6.0" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má Polská lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "2" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má Německá lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Jaká je maximalní rychlost sběrnice CAN? (V reálném čase)", ChoiceA = "3,4Mbps", ChoiceB = "10Mbps", ChoiceC = "125kbps", ChoiceD = "10kbps", CorrectChoice = "10Mbps" });

        }

    }
    public class QuestionObject
    {
        public string QuestionText { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string CorrectChoice { get; set; }
    }
}
