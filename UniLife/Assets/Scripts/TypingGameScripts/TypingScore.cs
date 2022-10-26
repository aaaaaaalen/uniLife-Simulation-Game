using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingScore : MonoBehaviour
{
    public static TypingScore instance;
    public static int scoreValue = 0;
    public Text score;
    public int result;

    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        result = scoreValue;
        score.text = "Score: " + result.ToString();
    }
}
