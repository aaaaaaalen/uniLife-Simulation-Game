using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class next_page1 : MonoBehaviour
{
	public GameObject gui1;
	public GameObject gui2;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		GetComponent<Button>().onClick.AddListener(() => {
			gui1.SetActive(false);
			gui2.SetActive(true);
		});
	}
}
