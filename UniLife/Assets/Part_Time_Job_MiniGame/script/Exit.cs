using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Back()
    {
        score = player.instance.mark;
        score += (PlayerProfile.instance.CommunicationSkill*2);
        if (score >= 70)
        {
            PlayerProfile.instance.money += 1000;
            if (PlayerProfile.instance.happiness <= 90)
            {
                PlayerProfile.instance.happiness += 10;
            }
            else
            {
                PlayerProfile.instance.happiness = 100;
            }
            if (MainGameManager.instance.hours >= 23)
            {
                MainGameManager.instance.days += 1;
                MainGameManager.instance.hours = 0;
            }
            else
            {
                MainGameManager.instance.hours += 1;
            }
            if (PlayerProfile.instance.CommunicationSkill < 5)
            {
                PlayerProfile.instance.CommunicationSkill += 5;
            }

        }
        else if (score >= 50)
        {
            PlayerProfile.instance.money += 800;
            if (PlayerProfile.instance.happiness <= 92)
            {
                PlayerProfile.instance.happiness += 8;
            }
            else
            {
                PlayerProfile.instance.happiness = 100;
            }
            if (MainGameManager.instance.hours >= 23)
            {
                MainGameManager.instance.days += 1;
                MainGameManager.instance.hours = 0;
            }
            if (PlayerProfile.instance.CommunicationSkill < 7)
            {
                PlayerProfile.instance.CommunicationSkill += 3;
            }

        }
        else if (score >= 30)
        {
            PlayerProfile.instance.money += 600;
            if (PlayerProfile.instance.happiness <= 94)
            {
                PlayerProfile.instance.happiness += 6;
            }
            else
            {
                PlayerProfile.instance.happiness = 100;
            }
            if (MainGameManager.instance.hours >= 23)
            {
                MainGameManager.instance.days += 1;
                MainGameManager.instance.hours = 0;
            }
            if (PlayerProfile.instance.CommunicationSkill < 9)
            {
                PlayerProfile.instance.CommunicationSkill += 1;
            }

        }
        else
        {
            if (MainGameManager.instance.hours >= 23)
            {
                MainGameManager.instance.days += 1;
                MainGameManager.instance.hours = 0;
            }
        }

            SceneManager.LoadScene("MainWorld");

    }


}
