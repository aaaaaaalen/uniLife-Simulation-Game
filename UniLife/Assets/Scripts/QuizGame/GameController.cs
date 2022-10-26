using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class GameController : MonoBehaviour
{


    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public Text resultText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
    public GameObject roundEndDisplay;
    public SingleSubject singleSubject;

    private DataController dataController;
    private QuizData currentRoundData;
    private QuestionData[] questionPool;

    private string subName;
    private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private int finalScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        dataController = FindObjectOfType<DataController>();
        currentRoundData = dataController.GetCurrentRoundData();
        questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeCounter;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsCounter;
            scoreDisplayText.text = "Score: " + playerScore.ToString();
        }

        if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
            int skillPoint = PlayerProfile.instance.logicalSkill;
            finalScore = playerScore + skillPoint;
            if (finalScore < 50)
            {
                resultText.text = "Your Final result is Fail ! You need speed more time on study!";
                if (PlayerProfile.instance.happiness > 10)
                {
                    PlayerProfile.instance.happiness -= 10;
                }
                else
                {
                    PlayerProfile.instance.happiness = 0;
                }
                if (MainGameManager.instance.hours >= 23)
                {
                    MainGameManager.instance.days += 1;
                    MainGameManager.instance.hours = 0;
                }
                else
                {
                    MainGameManager.instance.hours += 1;
                }
                if (PlayerProfile.instance.logicalSkill > 2)
                {
                    PlayerProfile.instance.logicalSkill -= 2;
                }
            }
            else if (finalScore >= 50 && finalScore <= 64)
            {
                resultText.text = "Your Final result is Pass ! good job!";

                if (PlayerProfile.instance.happiness > 5)
                {
                    PlayerProfile.instance.happiness -= 5;
                }
                else
                {
                    PlayerProfile.instance.happiness = 0;
                }
                if (MainGameManager.instance.hours >= 23)
                {
                    MainGameManager.instance.days += 1;
                    MainGameManager.instance.hours = 0;
                }
                else
                {
                    MainGameManager.instance.hours += 1;
                }
                if (PlayerProfile.instance.logicalSkill >1)
                {
                    PlayerProfile.instance.logicalSkill -= 1;
                }
            }
            else if (finalScore >= 65 && finalScore <= 74)
            {
                resultText.text = "Your Final result is Credit ! Well done!";
                
                if (PlayerProfile.instance.happiness > 1)
                {
                    PlayerProfile.instance.happiness -= 1;
                }
                else
                {
                    PlayerProfile.instance.happiness = 0;
                }
                if (MainGameManager.instance.hours >= 23)
                {
                    MainGameManager.instance.days += 1;
                    MainGameManager.instance.hours = 0;
                }
                else
                {
                    MainGameManager.instance.hours += 1;
                }
 
            }
            else if (finalScore >= 75 && finalScore <= 84)
            {
                resultText.text = "Your Final result is distinction ! Brilliant job!";

                PlayerProfile.instance.money += 50;
                if (PlayerProfile.instance.happiness <= 95)
                {
                    PlayerProfile.instance.happiness += 5;
                }
                else
                {
                    PlayerProfile.instance.happiness = 100;
                }
                if (MainGameManager.instance.hours >= 23)
                {
                    MainGameManager.instance.days += 1;
                    MainGameManager.instance.hours = 0;
                }
                else
                {
                    MainGameManager.instance.hours += 1;
                }
                if (PlayerProfile.instance.logicalSkill < 10)
                {
                    PlayerProfile.instance.logicalSkill += 1;
                }
            }
            else if (finalScore >= 85)
            {
                resultText.text = "Your Final result is High distinction ! I am so proud to you!";

                PlayerProfile.instance.money += 100;
                if (PlayerProfile.instance.happiness <= 90)
                {
                    PlayerProfile.instance.happiness += 10;
                }
                else
                {
                    PlayerProfile.instance.happiness = 100;
                }
                if (MainGameManager.instance.hours >= 23)
                {
                    MainGameManager.instance.days += 1;
                    MainGameManager.instance.hours = 0;
                }
                else
                {
                    MainGameManager.instance.hours += 1;
                }
                if (PlayerProfile.instance.logicalSkill < 9)
                {
                    PlayerProfile.instance.logicalSkill += 2;
                }
            }

            EndRound();
        }

    }

    public void EndRound()
    {
        isRoundActive = false;

        questionDisplay.SetActive(false);
        roundEndDisplay.SetActive(true);
    }

    public void ReturnToMenu()
    {
        subName = QuizType.instance.name;
        string tempName;

        for (int i = 0; i < StudentSubject.instance.playerSubjectTemp.childCount; i++)
        {
            tempName = StudentSubject.instance.playerSubjectTemp.GetChild(i).GetComponent<SingleSubject>().subName.ToString();
            StudentSubject.instance.playerSubjectTemp.GetChild(i).GetComponent<SingleSubject>().mark = finalScore;
            if (subName == tempName && finalScore >= 50)
            {
                PassedSubject.instance.quizMark.Add(finalScore);
                StudentSubject.instance.playerSubjectTemp.GetChild(i).GetComponent<SingleSubject>().isPassed = true;
                PassedSubject.instance.subjectInPlayerPs.Add(StudentSubject.instance.playerSubjectTemp.GetChild(i).gameObject);
                StudentSubject.instance.subjectInPlayer.Remove(StudentSubject.instance.playerSubjectTemp.GetChild(i).gameObject);
                for (int j = 0; j < PassedSubject.instance.subjectInPlayerPs.Count; j++)
                {
                    PassedSubject.instance.subjectInPlayerPs[j].transform.SetParent(PassedSubject.instance.playerSubjectTempPs);
                }
            }
            else if (subName == tempName && finalScore < 50)
            {
                StudentSubject.instance.subjectInPlayer.Remove(StudentSubject.instance.playerSubjectTemp.GetChild(i).gameObject);
                StudentCenter.instance.subjectsInCenter.Add(StudentSubject.instance.playerSubjectTemp.GetChild(i).gameObject);
            }

        }

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 4);
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Time: " + Mathf.Round(timeRemaining).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }

        }
    }
}