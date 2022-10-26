using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
[System.Serializable]
public class SaveData
{
    
    public int money;
    public int happiness;
    public int days;
    public int logicalSkill;
    public int CommunicationSkill;
    public float[] position;
   
    
    public SaveData(PlayerProfile player)
    {
        money = player.money;
        happiness = player.happiness;
        days = player.days;
        CommunicationSkill = player.CommunicationSkill;
        logicalSkill = player.logicalSkill;


        position = new float[3];
        position[0] = GameObject.FindWithTag("MainPlayer").transform.position.x;
        Debug.Log(position[0]);
        position[1] = GameObject.FindWithTag("MainPlayer").transform.position.y;
        Debug.Log(position[2]);
        position[2] = GameObject.FindWithTag("MainPlayer").transform.position.z;
        Debug.Log(position[2]);
    }




}
