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
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má česká lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
            Questions.Add(new QuestionObject { QuestionText = "Jaký je nejnovější .NET?", ChoiceA = "3.2", ChoiceB = "4.2", ChoiceC = "5.0", ChoiceD = "6.0", CorrectChoice = "6.0" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má Polská lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "2" });
            Questions.Add(new QuestionObject { QuestionText = "Kolik barev má Německá lajka.", ChoiceA = "1", ChoiceB = "2", ChoiceC = "3", ChoiceD = "4", CorrectChoice = "3" });
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
