using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class player : MonoBehaviour
{
    public NavMeshAgent agent;
    private Animator animator;
    public bool enter_dish_pot =false;
    private Transform hand;
    private bool food_destroy;
    public GameObject[] foods;
    private GameObject cook;
    private GameObject obj;
    private GameObject dish;
    public GameObject new_food;
    public int mark = 0;

    public static player instance;


    private void Awake()
    {

        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        hand = GameObject.FindGameObjectWithTag("hand").transform;
        cook = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //animator.SetBool("isWalking", true);
            if (Physics.Raycast(ray, out hit))
            {
                obj = hit.collider.gameObject;
                if (obj.tag == "dish4")
                {
                    if (hand.GetComponentsInChildren<Transform>(true).Length >= 1)
                    {
                        dish = GameObject.FindGameObjectWithTag("dish4");
                        new_food = Instantiate(foods[0], dish.transform.position, Quaternion.identity);
                        new_food.transform.SetParent(dish.transform);
                        Destroy(hand.GetChild(0).gameObject);
                    }
                }
                    
            }

           
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //animator.SetBool("isWalking", true);
            if (Physics.Raycast(ray, out hit))
            {

                agent.SetDestination(hit.point);
            }


        }
        if (cook.GetComponent<cook>().food_destroy == true)
            //for(int i = 0; i < hand.childCount; i++)
            //{
            //    if (hand.GetChild(i).childCount == 0)
            //    {
            //        GameObject newSelected = Instantiate(foods[0], hand.position, Quaternion.identity) as GameObject;
            //        newSelected.transform.SetParent(hand);
            //    }
            //}
            if (hand.GetComponentsInChildren<Transform>(true).Length <= 1)
            {
                if (cook.GetComponent<cook>().getTag() == "food1")
                {
                    GameObject newSelected = Instantiate(foods[0], hand.position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(hand);
                }
                else if (cook.GetComponent<cook>().getTag() == "food2")
                {
                    GameObject newSelected = Instantiate(foods[1], hand.position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(hand);
                }
                else if (cook.GetComponent<cook>().getTag() == "food3")
                {
                    GameObject newSelected = Instantiate(foods[2], hand.position, Quaternion.identity) as GameObject;
                    newSelected.transform.SetParent(hand);
                }

            }
    }

   

    //testing***********************************
    private void onTriggerStay(Collider other)
    {
        if(other.gameObject.tag.Equals("dish"))
        {
            enter_dish_pot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("dish"))
        {
            enter_dish_pot = false;
        }
    }

    public bool getDishPot()
    {
        return enter_dish_pot;
    }
    //testing***********************************
}
