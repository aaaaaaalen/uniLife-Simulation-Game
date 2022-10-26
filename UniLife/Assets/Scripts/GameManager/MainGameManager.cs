using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    public int days;
    public int hours;

    public bool needStopTime = false;
    

    // Start is called before the first frame update

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
        {
            Destroy(gameObject);

        }
    }

    void Start()
    {
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(30.0f);
            if (!needStopTime)
            {
                hours++;
                if(hours >= 24)
                {
                    days++;
                    hours = 0;

                    PlayerProfile.instance.money += 100;
                    PlayerProfile.instance.happiness -= 10;

                    if(PlayerProfile.instance.logicalSkill > 1)
                    {
                        PlayerProfile.instance.logicalSkill -= 1;
                    }
                    if (PlayerProfile.instance.CommunicationSkill > 1)
                    {
                        PlayerProfile.instance.CommunicationSkill -= 1;
                    }
                }
            }
        }
    }
}
