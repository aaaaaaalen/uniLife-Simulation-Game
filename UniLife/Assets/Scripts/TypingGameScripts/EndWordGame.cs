using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndWordGame : MonoBehaviour
{
    WordGameOver overControl;

    private void Awake()
    {
        overControl = WordGameOver.instance;
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Finish")
        {
            // Game Finishes and goes back to main world
            //SceneManager.LoadScene("MainWorld");
            overControl.Show();
        }
    }


}
