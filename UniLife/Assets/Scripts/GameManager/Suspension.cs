using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Suspension : MonoBehaviour
{
    public GameObject suspensionPanel;
    // Start is called before the first frame update
    void Start()
    {      
        if (PlayerProfile.instance.happiness <= 0)
        {
            suspensionPanel.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProfile.instance.happiness <= 0)
        {
            suspensionPanel.SetActive(true);
        }
    }

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {

        Application.Quit();
    }

}
