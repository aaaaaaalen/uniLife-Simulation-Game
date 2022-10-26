using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class MenuScreenController : MonoBehaviour
{
    public Text quizInfo;

    void Start()
    {
        if (QuizType.instance.type == 0)
        {
            quizInfo.text = "Where come to the Final exam for " + QuizType.instance.name + " This Exam is hold by Art School";
        }else if(QuizType.instance.type == 1)
        {
            quizInfo.text = "Where come to the Final exam for " + QuizType.instance.name + " This Exam is hold by Businese School";
        }
        else if (QuizType.instance.type == 2)
        {
            quizInfo.text = "Where come to the Final exam for " + QuizType.instance.name + " This Exam is hold by Engeering School";
        }
        else if (QuizType.instance.type == 3)
        {
            quizInfo.text = "Where come to the Final exam for " + QuizType.instance.name + " This Exam is hold by Science School";
        }

    }

    public void StartGame()
    {
        
        SceneManager.LoadScene("QuizGameMain");
    }
}