using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/

public class AnswerButton : MonoBehaviour
{

    public Text answerText;

    private AnswerData answerData;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }


    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}