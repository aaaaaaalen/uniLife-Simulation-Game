using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class quit : MonoBehaviour
{
	public int score;
    public Text scoreText;

    public void Quitgame()
	{
        score = int.Parse(scoreText.text);
        score += (PlayerProfile.instance.logicalSkill * 2);

        if (score >= 50)
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
                PlayerProfile.instance.happiness += 1;
            }

        }
        else if (score >= 40)
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

        }
        else if (score >= 20)
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
        else if (score <= 20 && score >= 5)
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 7);
	}

	
}
