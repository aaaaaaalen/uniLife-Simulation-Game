using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* @author $Yafei Zhang$
*
* @date - $2021/5/21$ 
*/
public class QuizType : MonoBehaviour
{
    public static QuizType instance;

    public int type;

    public string name;

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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ;

    }
}
