using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pt_title : MonoBehaviour
{
    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("mini_game");
    }
}
