using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Text scoreText;
    public int score;

    private void Awake() {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        score = int.Parse(scoreText.text);

        
    }

    private void Start() {
        Bird.GetInstance().OnDied += Bird_OnDied;
        Hide();
    }

    private void Bird_OnDied(object sender, System.EventArgs e) { 
        scoreText.text = Level.GetInstance().GetPipesPassedScore().ToString();
        Show();
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    public void Back()
    {
        score += (PlayerProfile.instance.logicalSkill*2);
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
        else if(score >= 80)
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
    }

}


