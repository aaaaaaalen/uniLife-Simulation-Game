using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class StudentCenter : MonoBehaviour
{
    public static StudentCenter instance;

    public List<GameObject> subjectsInCenter = new List<GameObject>();
    public Transform subjectsInCenterTransform;
    public GameObject subjectsPeafab;
    public List<Subjects> subjectsInfoInCenter = new List<Subjects>();

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
        GenerateSubjectsInCenter();
    } 

    public void GenerateSubjectsInCenter()
    {

        subjectsInCenter = new List<GameObject>();

        for(int i = 0; i < subjectsInfoInCenter.Count; i++)
        {
            bool enrolInfo = subjectsInfoInCenter[i].isEnroled;
            bool passInfo = subjectsInfoInCenter[i].isPassed;

            SubjectsName _subName = subjectsInfoInCenter[i].subName;

            subjectsPeafab.GetComponent<SingleSubject>().subName = _subName;

            GameObject _gameobject = Instantiate(subjectsPeafab, subjectsInCenterTransform, false);
            _gameobject.transform.localRotation = Quaternion.identity;
            _gameobject.transform.localScale = Vector3.one;
            _gameobject.name = "subInCentre";
            subjectsInCenter.Add(_gameobject);
            //SaveManager.subjectsInCenter.Add(_gameobject);



        }

    }
}
