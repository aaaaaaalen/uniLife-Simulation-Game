using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class customer : MonoBehaviour
{
    public GameObject waiting_point;
    public GameObject booking_point;
    public GameObject[] seat_point;
    public customer_spawn c_spawn;
    public NavMeshAgent agent;
    public int waiting_number;
    private Animator animator;
    private Ray ray;
    private GameObject obj;
    private RaycastHit hit;
    private GameObject exit;
    public GameObject customer_sp;
    private GameObject Player;
    public bool stay_booking_point;
    public GameObject ui5;
    public float timer = 3.0f;
    private GameObject dish4;

    // Start is called before the first frame update
    void Start()
    {
         dish4 = GameObject.FindGameObjectWithTag("dish4");
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        seat_point[0] = GameObject.FindGameObjectWithTag("seat_point1");
        seat_point[1] = GameObject.FindGameObjectWithTag("seat_point2");
        seat_point[2] = GameObject.FindGameObjectWithTag("seat_point3");
        seat_point[3] = GameObject.FindGameObjectWithTag("seat_point4");
        exit = GameObject.FindGameObjectWithTag("Exit");
        customer_sp = GameObject.FindGameObjectWithTag("borning");
        Player = GameObject.FindGameObjectWithTag("Player");

        if (Vector3.Distance(this.gameObject.transform.position, booking_point.transform.position) > 3.5f)
        {
            agent.SetDestination(waiting_point.transform.position);
            //animator.SetBool("isWalking", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                obj = hit.collider.gameObject;
                if (obj.tag == "booking_table")
                {
                    customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
                    if (cc.seat1 == true && stay_booking_point == true)
                    {
                        agent.SetDestination(seat_point[0].transform.position);
                        
                    }else if (cc.seat2 == true && stay_booking_point == true)
                    {
                        agent.SetDestination(seat_point[1].transform.position);
                    }
                    else if (cc.seat3 == true && stay_booking_point == true)
                    {
                        agent.SetDestination(seat_point[2].transform.position);
                    }
                    else if (cc.seat4 == true && stay_booking_point == true)
                    {
                        agent.SetDestination(seat_point[3].transform.position);
                    }

                }

            }
            
        }

        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Exit")
        {
            player pp = Player.GetComponent<player>();
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            cc.ui1.SetActive(false);
            cc.spawn = true;
            //cc.customer_count -= 1;
            pp.mark += Random.Range(5,50);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "booking_table" && waiting_number ==1)
        {
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            cc.seat1 = true;
            stay_booking_point = true;
        }else if (other.gameObject.tag == "booking_table" && waiting_number == 2)
        {
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            cc.seat2 = true;
            stay_booking_point = true;
        }
        else if (other.gameObject.tag == "booking_table" && waiting_number == 3)
        {
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            cc.seat3 = true;
            stay_booking_point = true;
        }
        else if (other.gameObject.tag == "booking_table" && waiting_number == 4)
        {
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            cc.seat4 = true;
            stay_booking_point = true;
        }
        if (other.gameObject.tag == "seat1")
        {
            customer_spawn cc = customer_sp.GetComponent<customer_spawn>();
            player pp = Player.GetComponent<player>();
            Debug.Log(pp.mark);
            cc.ui1.SetActive(true);
            if (dish4.GetComponentsInChildren<Transform>().Length == 2)
            {
                
                agent.SetDestination(exit.transform.position);
                Debug.Log(pp.mark);
                Destroy(pp.new_food);
            }
        }
    }


    public void Init(customer_spawn spwan, int number)
    {
        c_spawn = spwan;
        c_spawn.customer_count++;
        
    }
    public int getWaiting_Number()
    {
        return waiting_number;
    }
}
