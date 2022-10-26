using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
* 
* @edits $Luke Merritt$
* 
* @date - $2021/5/24$
*/
public class Graduate : MonoBehaviour
{
    public GameObject DialogPanel;
    public GameObject DialogPanel2;
    public Text DialogText;
    public Text GraduateText;
    public string subType;
    public int artCount;
    public int busCount;
    public int engCount;
    public int sciCount;
    public int subCount;
    public int scoreCount = 0;
    public double avg;


    // Start is called before the first frame update
    public void OnTriggerEnter(Collider collider)
    {
        CheckGraduate();
        CountScount();
        Debug.Log(subCount);
        if (subCount >= 1)
        {
            DialogPanel2.SetActive(true);
            if (artCount >= 1)
            {
                if (avg >= 85.0)
                 {
                     GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelors Degree in Art with a High Distinction";
                 }
                 else if (avg >= 75)
                 {
                     GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Art with a Distinction";
                 }
                 else
                 {
                     GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Art";
                }

             }
             else if (busCount >= 4)
             {
                if (avg >= 85.0)
                 {
                     GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Business with a High Distinction";
                 }
                 else if (avg >= 75)
                 {
                     GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Business with a Distinction";
                 }
                 else
                 {
                GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Business";
                }            
            }
            else if (engCount >= 4)
            {
                if (avg >= 85.0)
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Engineering with a High Distinction";
                }
                else if (avg >= 75)
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Engineering with a Distinction";
                }
                else
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Engineering";
                }
            }
            else if (sciCount >= 4)
            {
                if (avg >= 85.0)
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Science with a High Distinction";
                }
                else if (avg >= 75)
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Science with a Distinction";
                }
                else
                {
                    GraduateText.text = "CONGRATULATIONS, YOU HAVE SUCCESSFULLY COMPLETED ALL THE SUBJECTS REQUIRED FOR A UNI-LIFE Bachelor Degree in Science";
                }
            }
        }
        else
        {
            DialogText.text = "You do not meet the requirements to gradate, Please check your Infomation panel";   
            DialogPanel.SetActive(true);
        }

    }

    public void CheckGraduate()
    {
        for (int i = 0; i < PassedSubject.instance.playerSubjectTempPs.childCount; i++)
        {

            subType = PassedSubject.instance.playerSubjectTempPs.GetChild(i).GetComponent<SingleSubject>().subjectsType.ToString();
            if (subType == "Art") 
            {
                artCount++;
            }
            else if (subType == "Businese")
            {
                busCount++;
            }
            else if (subType == "Engineering")
            {
                engCount++;
            }
            else if (subType == "Science")
            {
                sciCount++;
            }

            subCount++;             
        }

    }

    public void CountScount()
    {

       avg = PassedSubject.instance.quizMark.Count > 0 ? PassedSubject.instance.quizMark.Average() : 0.0;

    }

                public void EndGame()
    {

        Application.Quit();
    }
}
