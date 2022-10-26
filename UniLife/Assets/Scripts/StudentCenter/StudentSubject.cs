using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class StudentSubject : MonoBehaviour
{
    public static StudentSubject instance;

    public Transform playerSubjectTemp;

    public List<GameObject> subjectInPlayer = new List<GameObject>();


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
