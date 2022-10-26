using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class StudentCentre : MonoBehaviour
{
    StudentCenterUI ScPanel;

    void Start()
    {
        ScPanel = StudentCenterUI.instance;
    }

    void OnTriggerEnter(Collider collider)
    {
        ScPanel.OpenStudentCenter();
    }

}
