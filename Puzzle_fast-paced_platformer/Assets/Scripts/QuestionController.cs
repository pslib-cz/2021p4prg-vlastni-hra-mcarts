using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Assets.Scripts.Models;

public class QuestionController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _questionMenu;
    GameObject _pickUp;
    [SerializeField] TextMeshProUGUI _choiceA; //jestli potøenuješ public 
    [SerializeField] TextMeshProUGUI _choiceB;
    [SerializeField] TextMeshProUGUI _choiceC;
    [SerializeField] TextMeshProUGUI _choiceD;

    [SerializeField] int _numberOfQuestion = 0;
    [SerializeField] TextMeshProUGUI _questionText;
    Question _questionList;
    OpenDoors od;

    [SerializeField] int _power = 0;
    [SerializeField] List<GameObject> _doors;
    [SerializeField] List<GameObject> _consoles;

    Question qs;
    void Start()
    {
        _questionMenu.SetActive(false);
        qs = new Question();
        
    }

    // Update is called once per frame
    void Update()
    {
        od = GetComponentInChildren<OpenDoors>();
    }
    public void SeeQuestion(Collider2D collider, GameObject a)
    {
        _pickUp = a;//.GetComponentInChildren();
        _questionMenu.SetActive(true);
         
        if (_numberOfQuestion > (qs.Questions.Count - 1))
        {
            _numberOfQuestion = 0;
        }
        _questionText.text = qs.Questions[_numberOfQuestion].QuestionText;
        _choiceA.text = qs.Questions[_numberOfQuestion].ChoiceA;
        _choiceB.text = qs.Questions[_numberOfQuestion].ChoiceB;
        _choiceC.text = qs.Questions[_numberOfQuestion].ChoiceC;
        _choiceD.text = qs.Questions[_numberOfQuestion].ChoiceD;

    }
    public void ClickChoice(string choice)
    {
        bool correctAnswer = false;
        switch (choice)
        {
            case "A":
                string answerA = qs.Questions[_numberOfQuestion].ChoiceA;
                if (answerA == qs.Questions[_numberOfQuestion].CorrectChoice)
                {
                    correctAnswer = true;
                }
                break;
            case "B":
                string answerB = qs.Questions[_numberOfQuestion].ChoiceB;
                if (answerB == qs.Questions[_numberOfQuestion].CorrectChoice)
                {
                    correctAnswer = true;
                }
                break;
            case "C":
                string answerC = qs.Questions[_numberOfQuestion].ChoiceC;
                //string correct = questionList[_numberOfQuestion].CorrectChoice;
                if (answerC == qs.Questions[_numberOfQuestion].CorrectChoice)
                {
                    correctAnswer = true;
                }
                break;
            case "D":
                string answerD = qs.Questions[_numberOfQuestion].ChoiceD;
                if (answerD == qs.Questions[_numberOfQuestion].CorrectChoice)
                {
                    correctAnswer = true;
                }
                break;
        }
        if (correctAnswer)
        {
            _pickUp .SetActive(false);
            _power++;
            var ahoj = _pickUp.GetComponentInChildren<GameObject>();
            od.OpenDoor();
            od = null;
        }
        _questionMenu.SetActive(false);
        
        _numberOfQuestion++;
        Time.timeScale = 1;
    }
}
