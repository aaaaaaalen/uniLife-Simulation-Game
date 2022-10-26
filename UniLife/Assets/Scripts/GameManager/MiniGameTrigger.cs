using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class MiniGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider collider)
    {
        if (collider.name == "FlappyBirdGame")
        {
            SceneManager.LoadScene("FlappyBird");
        }
        else if (collider.name == "JumpGame")
        {
            SceneManager.LoadScene("jump");
        }
        else if (collider.name == "WordGame")
        {
            SceneManager.LoadScene("TypingGame");
        }
        else if (collider.name == "PartTime")
        {
            SceneManager.LoadScene("pt_title");
        }

    }
}
