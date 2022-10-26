using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class SubjectsDatabase : MonoBehaviour
{
    public static SubjectsDatabase instance;
    public List<Subjects> subjectsInfo = new List<Subjects>();

    public Dictionary<SubjectsName, SubjectsType> subjectsTypeLoopUp;
    public Dictionary<SubjectsName, Sprite> subjectsSpriteLoopUp;
    public Dictionary<SubjectsName, int> subjectsFeeLoopUp;
    public Dictionary<SubjectsName, int> subjectsCreditLoopUp;
    public Dictionary<SubjectsName, string> subjectsDescriptionLoopUp;
    public Dictionary<SubjectsName, bool> enroledSubjectsLoopUp;
    public Dictionary<SubjectsName, bool> passedSubjectsLoopUp;
    public Dictionary<SubjectsName, int> markSubjectsLoopUp;


    private void Awake()
    {
        instance = this;

        subjectsTypeLoopUp = new Dictionary<SubjectsName, SubjectsType>();
        for(int i = 0; i < subjectsInfo.Count; i++)
        {
            subjectsTypeLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].subjectsType);
        }

        subjectsSpriteLoopUp = new Dictionary<SubjectsName, Sprite>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            subjectsSpriteLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].subSprite);
        }

        subjectsFeeLoopUp = new Dictionary<SubjectsName, int>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            subjectsFeeLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].fee);
        }

        subjectsCreditLoopUp = new Dictionary<SubjectsName, int>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            subjectsCreditLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].credit);
        }

        subjectsDescriptionLoopUp = new Dictionary<SubjectsName, string>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            subjectsDescriptionLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].shortDescription);
        }

        enroledSubjectsLoopUp = new Dictionary<SubjectsName, bool>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            enroledSubjectsLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].isEnroled);
        }

        passedSubjectsLoopUp = new Dictionary<SubjectsName, bool>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            passedSubjectsLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].isPassed);
        }

        markSubjectsLoopUp = new Dictionary<SubjectsName, int>();
        for (int i = 0; i < subjectsInfo.Count; i++)
        {
            markSubjectsLoopUp.Add(subjectsInfo[i].subName, subjectsInfo[i].mark);
        }

       
    }
}
[System.Serializable]
public class Subjects
{
    public SubjectsType subjectsType;
    public SubjectsName subName;
    public Sprite subSprite;
    public int fee;
    public int credit;
    public string shortDescription;
    public bool isEnroled;
    public bool isPassed;
    public int mark;

}

public enum SubjectsType
{
    Art,
    Businese,
    Engineering,
    Science,
}

public enum SubjectsName
{
    ART1001,
    ART1002,
    ART1003,
    ART2001,
    ART2002,
    ART3001,
    BUS1001,
    BUS1002,
    BUS1003,
    BUS2001,
    BUS2002,
    BUS3001,
    ENG1001,
    ENG1002,
    ENG1003,
    ENG2001,
    ENG2002,
    ENG3001,
    SCI1001,
    SCI1002,
    SCI1003,
    SCI2001,
    SCI2002,
    SCI3001,

}