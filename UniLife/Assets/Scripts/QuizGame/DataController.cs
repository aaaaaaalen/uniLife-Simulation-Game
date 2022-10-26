using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class DataController : MonoBehaviour
{
    public QuizData[] quiz_Data;
    public int quizType;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        SceneManager.LoadScene("QuizGameMenuScreen");
    }

    public QuizData GetCurrentRoundData()
    {
        quizType = QuizType.instance.type;
        return quiz_Data[quizType];
    }

    // Update is called once per frame
    void Update()
    {

    }
}