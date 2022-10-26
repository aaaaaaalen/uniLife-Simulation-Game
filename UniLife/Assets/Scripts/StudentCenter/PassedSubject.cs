using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class PassedSubject : MonoBehaviour
{
    public static PassedSubject instance;

    public Transform playerSubjectTempPs;

    public List<GameObject> subjectInPlayerPs = new List<GameObject>();

    public List<int> quizMark;

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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
