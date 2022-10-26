using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class SingleSubject : MonoBehaviour, IPointerClickHandler
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

    public Text subNametext;

    SubjectsDatabase subjectdatabase;

    // Start is called before the first frame update
    void Start()
    {
        subjectdatabase = SubjectsDatabase.instance;
        subNametext.color = Color.black;
        updateInfo();
    }

    public void updateInfo()
    {
        subSprite = subjectdatabase.subjectsSpriteLoopUp[subName];
        fee = subjectdatabase.subjectsFeeLoopUp[subName];
        credit = subjectdatabase.subjectsCreditLoopUp[subName];
        shortDescription = subjectdatabase.subjectsDescriptionLoopUp[subName];
        isEnroled = subjectdatabase.enroledSubjectsLoopUp[subName];
        isPassed = subjectdatabase.passedSubjectsLoopUp[subName];
        mark = subjectdatabase.markSubjectsLoopUp[subName];
        subjectsType = subjectdatabase.subjectsTypeLoopUp[subName];

        if (subNametext != null)
        {
            subNametext.text = subName.ToString();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        subNametext.color = Color.red;
        if(StudentCenterUI.instance.singleSubject != null && StudentCenterUI.instance.singleSubject != this)
        {
            StudentCenterUI.instance.singleSubject.subNametext.color = Color.black;
        }
        StudentCenterUI.instance.singleSubject = this;
        StudentCenterUI.instance.UpdateUI();
    }
}
