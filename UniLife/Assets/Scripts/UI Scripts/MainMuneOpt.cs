using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class MainMuneOpt : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject loadScreen;
    public GameObject OptionMenu;
    public Slider LoadingBar;
    public Text LoadingText;
    public Toggle BgmToggle;
    public AudioSource BgmAudio;


    /*private void Start()
    {
        BgmAudio = GetComponent<AudioSource>();


    }*/
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

    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel());
    }

    public void optionButton()
    {
        MainMenu.SetActive(false);
        OptionMenu.SetActive(true);
    }

    public void backButton()
    {
        OptionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }

    IEnumerator LoadLevel()
    {
        MainMenu.SetActive(false);
        loadScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            LoadingBar.value = operation.progress;

            LoadingText.text = operation.progress * 100 + "%";

            if (operation.progress >= 0.9f)
            {
                LoadingBar.value = 1;

                LoadingText.text = "Press AnyKey To Contine";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }
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
}
