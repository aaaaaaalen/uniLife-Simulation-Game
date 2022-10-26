using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/


public class StudentCenterUI : MonoBehaviour
{
    public static StudentCenterUI instance;
    
    public GameObject StudentCenterPanal;
    public GameObject DialogPanal;
    public Image subImage;
    public Text subName;
    public Text subFee;
    public Text subCredit;
    public Text subDescription;
    public Text titleText;
    public Text bodyText;
    public Text SchoolText;
    public bool isEnroled;
    public bool isPassed;



    public Button enrolButton;
    public SingleSubject singleSubject;
    public Transform studentCenterScrollView;
    public Transform playerSubjectScrollView;
    public Transform passedSubjectScrollView;


    public Image subEnImage;
    public Text SubCredit;
    public Text SubMark;
    public Text SubResult;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
    }

    public void CourseRuleDiaLog()
    {
        DialogPanal.SetActive(true);
        titleText.text = "Couse Rule";
        bodyText.text = "Student can graduate from Uni by finishing more than 6 subjects and get more than 36 credit points. " +
            "If Student finished more than 4 subjects in the same faculty. Student will get a specific degree from uni." +
            "Student Can enrol different subjects from 4 faculties in student Centre By choose the subject from the list and click the enrol button. " +
            "The additional information like, tuition fee, credit point, and short description will be shown  after choosing the subject.";
    }

    public void CloseDiaLog()
    {
        DialogPanal.SetActive(false);
        titleText.text = "";
        bodyText.text = "";
    }


    // Update is called once per frame
    public void OpenStudentCenter()
    {

        StudentCenterPanal.SetActive(true);
        DialogPanal.SetActive(false);
        //subject in Student Center
        for (int i = 0; i < studentCenterScrollView.childCount; i++)
        {
            Destroy(studentCenterScrollView.GetChild(i).gameObject);
        }
        for(int i = 0; i < StudentCenter.instance.subjectsInCenter.Count; i++)
        {
            GameObject _gameObject = Instantiate(StudentCenter.instance.subjectsInCenter[i],studentCenterScrollView,false);
            _gameObject.transform.localRotation = Quaternion.identity;
            _gameObject.transform.localScale = Vector3.one;
            _gameObject.name = "SubInCenter";

        }
        //subject in Player
        for (int i = 0; i < playerSubjectScrollView.childCount; i++)
        {
            //Debug.Log("3: " + i);
            Destroy(playerSubjectScrollView.GetChild(i).gameObject);
        }
        for (int i = 0; i < StudentSubject.instance.subjectInPlayer.Count; i++)
        {
            //Debug.Log("4: " + i);
            GameObject _gameObject = Instantiate(StudentSubject.instance.subjectInPlayer[i], playerSubjectScrollView, false);
            _gameObject.transform.localRotation = Quaternion.identity;
            _gameObject.transform.localScale = Vector3.one;
            _gameObject.name = "SubInPlayer";
        }

        //Passed subject
        for (int i = 0; i < passedSubjectScrollView.childCount; i++)
        {
            //Debug.Log("3: " + i);
            Destroy(passedSubjectScrollView.GetChild(i).gameObject);
        }
        for (int i = 0; i < PassedSubject.instance.subjectInPlayerPs.Count; i++)
        {
            //Debug.Log("4: " + i);
            GameObject _gameObject = Instantiate(PassedSubject.instance.subjectInPlayerPs[i], passedSubjectScrollView, false);
            _gameObject.transform.localRotation = Quaternion.identity;
            _gameObject.transform.localScale = Vector3.one;
            _gameObject.name = "SubInPlayer";
            _gameObject.GetComponent<SingleSubject>().mark = PassedSubject.instance.quizMark[i];
        }

        subImage.enabled = false;
        subName.text = "";
        subFee.text = "";
        subCredit.text = "";
        subDescription.text = "";
        enrolButton.interactable = false;
    }

    public void UpdateUI()
    {
        subImage.enabled = true;
        subImage.sprite = singleSubject.subSprite;
        subName.text = "Name: " + singleSubject.subName.ToString();
        subFee.text = "Subject Fee: " + singleSubject.fee.ToString();
        subCredit.text = "Subject Credit: " + singleSubject.credit.ToString();
        subDescription.text = "Subject Description: " + singleSubject.shortDescription; ;
        isEnroled = singleSubject.isEnroled;
        isPassed = singleSubject.isPassed;
        enrolButton.interactable = true;
        subEnImage.sprite = singleSubject.subSprite;
        SubCredit.text = "Credit: " + singleSubject.credit.ToString();
        SubResult.text = "Mark: " + singleSubject.mark.ToString();
        SchoolText.text = singleSubject.subjectsType.ToString() + " School";
    }

    public void enrolSubject()
    {
        if (PlayerProfile.instance.money >= singleSubject.fee)
        {
            singleSubject.gameObject.transform.SetParent(playerSubjectScrollView);
            PlayerProfile.instance.money -= singleSubject.fee;
            singleSubject.isEnroled = true;
            UpdateUI();
        }
        else
        {
            DialogPanal.SetActive(true);
            titleText.text = "Warning";
            bodyText.text = "You Don't Have Enough Money.";
        }
    }

    public void DropSubject()
    {
        //Debug.Log(singleSubject.result);
        if (singleSubject.mark == 0)
        {
            
            singleSubject.gameObject.transform.SetParent(studentCenterScrollView);
            PlayerProfile.instance.money += singleSubject.fee/2;
            singleSubject.isEnroled = false ;
            UpdateUI();
        }
        else
        {
            Debug.Log("You already finshed Exam for this Subject.");
        }
    }

    public void closeScPanel()
    {
        StudentCenterPanal.SetActive(false);
        //CameraClearFlags previous information in student centre.
        StudentCenter.instance.subjectsInCenter.Clear();
        for (int i = 0; i < StudentCenter.instance.subjectsInCenterTransform.childCount; i++)
        {
            GameObject.Destroy(StudentCenter.instance.subjectsInCenterTransform.GetChild(i).gameObject);
        }
        //add new subject list into town info
        for (int i = 0; i < studentCenterScrollView.childCount; i++)
        {
            StudentCenter.instance.subjectsInCenter.Add(studentCenterScrollView.GetChild(i).gameObject);
        }

        for (int i = 0; i < StudentCenter.instance.subjectsInCenter.Count; i++)
        {
            StudentCenter.instance.subjectsInCenter[i].transform.SetParent(StudentCenter.instance.subjectsInCenterTransform);
        }


        StudentSubject.instance.subjectInPlayer.Clear();
        for (int i = 0; i < StudentSubject.instance.playerSubjectTemp.childCount; i++)
        {
            GameObject.Destroy(StudentSubject.instance.playerSubjectTemp.GetChild(i).gameObject);
        }
            
        for (int i = 0; i < playerSubjectScrollView.childCount; i++)
        {
            StudentSubject.instance.subjectInPlayer.Add(playerSubjectScrollView.GetChild(i).gameObject);
        }

        for (int i = 0; i < StudentSubject.instance.subjectInPlayer.Count; i++)
        {
            StudentSubject.instance.subjectInPlayer[i].transform.SetParent(StudentSubject.instance.playerSubjectTemp);
        }

        PassedSubject.instance.subjectInPlayerPs.Clear();
        for (int i = 0; i < PassedSubject.instance.playerSubjectTempPs.childCount; i++)
        {
            GameObject.Destroy(PassedSubject.instance.playerSubjectTempPs.GetChild(i).gameObject);
        }

        for (int i = 0; i < passedSubjectScrollView.childCount; i++)
        {
            PassedSubject.instance.subjectInPlayerPs.Add(passedSubjectScrollView.GetChild(i).gameObject);
        }

        for (int i = 0; i < PassedSubject.instance.subjectInPlayerPs.Count; i++)
        {
            PassedSubject.instance.subjectInPlayerPs[i].transform.SetParent(PassedSubject.instance.playerSubjectTempPs);
        }
    }

}
