using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/

public class InGameMenu : MonoBehaviour
{ 
    public GameObject OptionMenu;
    public GameObject InfoPanel;
    public GameObject InfoDis1;
    public GameObject InfoDis2;
    public GameObject InfoDis3;
    public GameObject DialogPanel;
    public Toggle BgmToggle;
    public AudioSource BgmAudio;
    public static bool GameIsPaused = false;
    public AudioMixer BgmMixer;

    public Transform studentCenterScrollView;
    public Transform playerSubjectScrollView;
    public Transform passedSubjectScrollView;
    public Text dialogText;
    public Text dialogText1;


    public void Awake()
    {
        //BgmAudio = GetComponent<AudioSource>();
        // 1
        if (!PlayerPrefs.HasKey("BGM"))
        {
            PlayerPrefs.SetInt("BGM", 1);
            //Debug.Log(PlayerPrefs.GetInt("BGM"));
            BgmToggle.isOn = true;
            BgmAudio.enabled = true;
            PlayerPrefs.Save();
        }
        // 2
        else
        {
            if (PlayerPrefs.GetInt("BGM") == 0)
            {

                BgmAudio.enabled = false;
                BgmToggle.isOn = false;
            }
            else
            {
                BgmAudio.enabled = true;
                BgmToggle.isOn = true;
            }
        }
    }

    void Start()
    {

    }

    public void Resume()
    {
        OptionMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        OptionMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;

        //Debug.Log(SubjectsDatabase.instance.subjectsNameLoopUp[SubjectsType.Art]);
    }

    public void closeDialog()
    {
        DialogPanel.SetActive(false);
    }

    public void OpenInfo()
    {
        InfoPanel.SetActive(true);
        InfoDis1.SetActive(true);
        InfoDis2.SetActive(false);
        InfoDis3.SetActive(false);
        dialogText.gameObject.SetActive(false);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
        //in case open infor panel before Student Centre pabel, the following code with Destroy the content in student centre
        if (StudentSubject.instance.playerSubjectTemp.childCount != 0)
            {
                //subject in StudentCentre
            for (int i = 0; i < studentCenterScrollView.childCount; i++)
            {
                Destroy(studentCenterScrollView.GetChild(i).gameObject);
            }
            for (int i = 0; i < StudentCenter.instance.subjectsInCenter.Count; i++)
            {
             GameObject _gameObject = Instantiate(StudentCenter.instance.subjectsInCenter[i], studentCenterScrollView, false);
                _gameObject.transform.localRotation = Quaternion.identity;
                _gameObject.transform.localScale = Vector3.one;
                _gameObject.name = "SubInCenter";

            }
            //subject in Player
            for (int i = 0; i < playerSubjectScrollView.childCount; i++)
            {
                Destroy(playerSubjectScrollView.GetChild(i).gameObject);
            }
            for (int i = 0; i < StudentSubject.instance.subjectInPlayer.Count; i++)
            {
                GameObject _gameObject = Instantiate(StudentSubject.instance.subjectInPlayer[i], playerSubjectScrollView, false);
                _gameObject.transform.localRotation = Quaternion.identity;
                _gameObject.transform.localScale = Vector3.one;
                _gameObject.name = "SubInPlayer";
            }
                //Passed subject
        }
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
            _gameObject.GetComponent<SingleSubject>().mark = PassedSubject.instance.quizMark[i];
            Debug.Log(_gameObject.GetComponent<SingleSubject>().mark);
            Debug.Log(PassedSubject.instance.quizMark[i]);
        }

    }

    public void ResumeInfo()
    {
        InfoPanel.SetActive(false);
        InfoDis1.SetActive(false);
        InfoDis2.SetActive(false);
        InfoDis3.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;

        if (StudentSubject.instance.playerSubjectTemp.childCount != 0)
        {
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

    public void OpenInfoDis1()
    {
        InfoDis1.SetActive(true);
        InfoDis2.SetActive(false);
        InfoDis3.SetActive(false);
        dialogText.gameObject.SetActive(false);
    }

    public void OpenInfoDis2()
    {
        InfoDis2.SetActive(true);
        InfoDis1.SetActive(false);
        InfoDis3.SetActive(false);
        dialogText.gameObject.SetActive(false);

        if (StudentSubject.instance.playerSubjectTemp.childCount == 0)
        {
            dialogText.text = "No enrolled Subject!";
            dialogText.color = Color.white;
            dialogText.gameObject.SetActive(true);
        }
        if (PassedSubject.instance.subjectInPlayerPs.Count == 0)
        {
            dialogText1.text = "No passed Subject!";
            dialogText1.color = Color.white;
            dialogText1.gameObject.SetActive(true);
        }
    }

    public void OpenInfoDis3()
    {
        InfoDis3.SetActive(true);
        InfoDis1.SetActive(false);
        InfoDis2.SetActive(false);
        dialogText.gameObject.SetActive(false);

    }

    public void SettingVolume(float volume)
    {
        BgmMixer.SetFloat("BgmMixer", Mathf.Log10(volume)*20);
    }

    public void BgmToggleButton()

    {

        if (BgmToggle.isOn)
        {
            PlayerPrefs.SetInt("BGM", 1);
            BgmAudio.enabled = true;
            Debug.Log(PlayerPrefs.GetInt("BGM"));

        }
        else
        {
            PlayerPrefs.SetInt("BGM", 0);
            BgmAudio.enabled = false;
            Debug.Log(PlayerPrefs.GetInt("BGM"));

        }

    }

    public void EndGame()
    {

        Application.Quit();
    }
}
