using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class cook : MonoBehaviour
{
    public Transform foodPoints;
    public Transform[] food_point;
    public GameObject[] foods;

    private Ray ray;
    private RaycastHit hit;
    private GameObject obj;
    public bool food_destroy = false;
    private player p;
    private string tag;
    private Transform hand;
    public GameObject gui1, gui2, gui3;
    private float timer = 0.0f;
    private float max_time = 3.0f;
    private bool start_timer, pot1_pot1, pot1_pot2, pot1_pot3, pot2_pot1, pot2_pot2, pot2_pot3, pot3_pot1, pot3_pot2, pot3_pot3;
    public GameObject unable1, unable2, unable3;
    
    

    private void Start()
    {
        hand = GameObject.FindGameObjectWithTag("hand").transform;
    }
    void Update()
    {
        if (start_timer)
        {
            timer += Time.deltaTime;
            if (timer >= max_time)
            {
                //pot1
                if (pot1_pot1 && food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[0], food_point[0].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[0]);
                    timer = 0;
                    gui1.SetActive(false);
                    unable2.SetActive(false);
                    unable3.SetActive(false);


                } else if (pot2_pot1 && food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[1], food_point[0].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[0]);
                    timer = 0;
                    gui2.SetActive(false);
                    unable1.SetActive(false);
                    unable3.SetActive(false);



                } else if (pot3_pot1 && food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[2], food_point[0].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[0]);
                    timer = 0;
                    gui3.SetActive(false);
                    unable2.SetActive(false);
                    unable1.SetActive(false);



                }

                if (pot1_pot2 && food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[0], food_point[1].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[1]);
                    timer = 0;
                    gui1.SetActive(false);
                    unable2.SetActive(false);
                    unable3.SetActive(false);

                }
                else if (pot2_pot2 && food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[1], food_point[1].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[1]);
                    timer = 0;
                    gui2.SetActive(false);
                    unable1.SetActive(false);
                    unable3.SetActive(false);



                } else if (pot3_pot2 && food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[2], food_point[1].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[1]);
                    timer = 0;
                    gui3.SetActive(false);
                    unable2.SetActive(false);
                    unable1.SetActive(false);



                }

                if (pot1_pot3 && food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[0], food_point[2].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[2]);
                    timer = 0;
                    gui1.SetActive(false);
                    unable2.SetActive(false);
                    unable3.SetActive(false);


                } else if (pot2_pot3 && food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[1], food_point[2].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[2]);
                    timer = 0;
                    gui2.SetActive(false);
                    unable1.SetActive(false);
                    unable3.SetActive(false);


                } else if (pot3_pot3 && food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                {

                    GameObject newSelected = Instantiate(foods[2], food_point[2].position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(food_point[2]);
                    timer = 0;
                    gui3.SetActive(false);
                    unable2.SetActive(false);
                    unable1.SetActive(false);

                }


                timer = 0;
                start_timer = false;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                obj = hit.collider.gameObject;
                if(obj.tag == "pot")
                {
                    switch (obj.name)
                    {
                        case "pot1":
                            if (food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                
                                gui1.SetActive(true);
                                unable2.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot1_pot1 = true;
                                
                            }
                            else if (food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui1.SetActive(true);
                                unable2.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot1_pot2 = true;
                                
                            }
                            else if (food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui1.SetActive(true);
                                unable2.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot1_pot3 = true;
                            }
                            food_destroy = false;
                            break;
                        case "pot2":
                            if (food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                
                                gui2.SetActive(true);
                                unable1.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot2_pot1 = true;
                                
                            }
                            else if (food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui2.SetActive(true);
                                unable1.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot2_pot2 = true;
                            }
                            else if (food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui2.SetActive(true);
                                unable1.SetActive(true);
                                unable3.SetActive(true);
                                start_timer = true;
                                pot2_pot3 = true;
                            }
                            food_destroy = false;
                            break;
                        case "pot3":
                            if (food_point[0].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                
                                gui3.SetActive(true);
                                unable2.SetActive(true);
                                unable1.SetActive(true);
                                start_timer = true;
                                pot3_pot1 = true;
                            }
                            else if (food_point[1].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui3.SetActive(true);
                                unable2.SetActive(true);
                                unable1.SetActive(true);
                                start_timer = true;
                                pot3_pot2 = true;
                            }
                            else if (food_point[2].GetComponentsInChildren<Transform>(true).Length <= 1)
                            {
                                gui3.SetActive(true);
                                unable2.SetActive(true);
                                unable1.SetActive(true);
                                start_timer = true;
                                pot3_pot3 = true;
                            }
                            food_destroy = false;
                            break;
                    }
                }
                else if (obj.tag =="food1" || obj.tag == "food2" || obj.tag == "food3")
                {
                    
                    Destroy(obj.gameObject);
                    food_destroy = true;
                    setTag(obj.tag);
                    
                }else if (obj.tag =="bin")
                {
                    if(hand.GetComponentsInChildren<Transform>(true).Length >= 1)
                    {
                        Destroy(hand.GetChild(0).gameObject);
                    }
                }
                else
                {
                    food_destroy = false;
                }
            }
        }
    }

    public void setTag(string tag)
    {
        this.tag = tag;
    }

    public string getTag()
    {
        return tag;
    }
    
}
