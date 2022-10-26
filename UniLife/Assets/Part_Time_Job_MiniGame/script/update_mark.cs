using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_mark : MonoBehaviour
{
    public Text mark;
    private GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        mark = this.GetComponent<Text>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player pp = Player.GetComponent<player>();
        mark.text = pp.mark.ToString();
    }
}
