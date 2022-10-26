using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtext : MonoBehaviour
{
    public Text moneyText;
    public Text happinessText;
    public Text dayText;
    public Text logicalSkillText;
    public Text CommunicationSkillText;
    public Text SkillText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + PlayerProfile.instance.money.ToString();
        happinessText.text = "Happiness: " + PlayerProfile.instance.happiness.ToString();
        int days = PlayerProfile.instance.days + 1;
        dayText.text = "This is your " + days.ToString() + " days in Uni";
        logicalSkillText.text = "logical Skill level: " + PlayerProfile.instance.logicalSkill.ToString();
        CommunicationSkillText.text = "Communication Skill level: " + PlayerProfile.instance.CommunicationSkill.ToString();
        SkillText.text = "Logical: " + PlayerProfile.instance.logicalSkill.ToString() + " / Communication: " + PlayerProfile.instance.CommunicationSkill.ToString();

    }
}
