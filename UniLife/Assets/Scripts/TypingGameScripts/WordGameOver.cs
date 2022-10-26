using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WordGameOver : MonoBehaviour
{
    public static WordGameOver instance;
    public GameObject overPanel;
    public int score;
    public Text result;
    TypingScore typingScore;

    private void Awake()
    {
        instance = this;
        typingScore = TypingScore.instance;
    }

    public void Show()
    {
        overPanel.SetActive(true);
        score = TypingScore.instance.result;


        score += (PlayerProfile.instance.logicalSkill * 2);
        //Debug.Log(score);
        if (score >= 100)
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
            if (PlayerProfile.instance.logicalSkill < 10)
            {
                PlayerProfile.instance.logicalSkill += 1;
            }

        }
        else if (score >= 80)
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

        }
        else if (score >= 60)
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

        }
        else if (score >= 40)
        {
            PlayerProfile.instance.money += 400;
            if (PlayerProfile.instance.happiness <= 96)
            {
                PlayerProfile.instance.happiness += 4;
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

        }
        else if (score >= 20)
        {
            PlayerProfile.instance.money += 200;
            if (PlayerProfile.instance.happiness <= 98)
            {
                PlayerProfile.instance.happiness += 2;
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

        }
        else
        {
            if (MainGameManager.instance.hours >= 23)
            {
                MainGameManager.instance.days += 1;
                MainGameManager.instance.hours = 0;
            }
        }
    }

    public void Back()
    {
        SceneManager.LoadScene("MainWorld");
    }
}
