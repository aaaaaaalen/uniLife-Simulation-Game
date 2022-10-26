using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class EngSchool : MonoBehaviour
{
    public GameObject DialogPanel;
    public Text DialogText;
    string subType;
    string subName;
    int quiztype;
    public void OnTriggerEnter(Collider collider)
    {
        if (CheckSubType() == true)
        {
            quiztype = 2;
            QuizType.instance.type = quiztype;
            SceneManager.LoadScene("QuizGameSetUp");
        }
        else
        {
            DialogText.text = "No Engineering subjects is enrolled";
            DialogPanel.SetActive(true);
        }

    }

    public bool CheckSubType()
    {
        for (int i = 0; i < StudentSubject.instance.playerSubjectTemp.childCount; i++)
        {
            subType = StudentSubject.instance.playerSubjectTemp.GetChild(i).GetComponent<SingleSubject>().subjectsType.ToString();
            subName = StudentSubject.instance.playerSubjectTemp.GetChild(i).GetComponent<SingleSubject>().subName.ToString();
            while (subType == "Engineering")
            {
                QuizType.instance.name = subName;
                return true;
            }

        }

        return false;
    }
}
