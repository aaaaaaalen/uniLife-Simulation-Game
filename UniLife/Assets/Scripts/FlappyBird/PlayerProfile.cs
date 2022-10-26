using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/

public class PlayerProfile : MonoBehaviour
{
    public int money;
    public int happiness;
    public int days;
    public int logicalSkill;
    public int CommunicationSkill;

    public static PlayerProfile instance;

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
        days = MainGameManager.instance.days;
    }

    private void Update()
    {
   
    }


    public void SavePlayer()
    {
        SaveManager.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        SaveData data = SaveManager.LoadPlayer();

        money = data.money;
        happiness = data.happiness;
        MainGameManager.instance.days = data.days - 1;
        days = MainGameManager.instance.days;
        logicalSkill = data.logicalSkill;
        logicalSkill = data.CommunicationSkill;

        Vector3 position;
        
        position.x= data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        GameObject.FindWithTag("MainPlayer").transform.position = position;
    }
}
