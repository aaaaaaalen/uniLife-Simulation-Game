using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class customer_spawn : MonoBehaviour
{
    public Transform customer;
    private Transform my_tranform;
    public int customer_count = 0;
    private int max_customer = 4;
    public float timer = 0;
    private bool bookpoint_is_empty = true;
    public Transform target;
	public bool seat1 = false;
    public bool seat2 = false;
    public bool seat3 = false;
    public bool seat4 = false;
    public GameObject cc;
    public Transform customer_;
    public int number;
    public bool spawn = true;
    public GameObject[] waiting_point;
    public GameObject booking_point;

    public GameObject ui1;

    Queue<GameObject> q1;
	
	// Start is called before the first frame update
	void Start()
    {
        my_tranform = this.transform;

        waiting_point[0] = GameObject.FindGameObjectWithTag("waiting_point1");
        waiting_point[1] = GameObject.FindGameObjectWithTag("waiting_point2");
        waiting_point[2] = GameObject.FindGameObjectWithTag("waiting_point3");
        waiting_point[3] = GameObject.FindGameObjectWithTag("waiting_point4");
        booking_point = GameObject.FindGameObjectWithTag("booking_point");
        //seat_point = GameObject.FindGameObjectWithTag("seat_point");
        q1 = new Queue<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

        if (customer_count >= max_customer)
        {
            return;
        }
        //timer -= Time.deltaTime;
        //if(timer <= 0)
        //{
        //timer = Random.value * 10.0f;
        //if(timer < 5)
        //{
        //    timer = 5;
        //}
        if (spawn)
        {
            customer_ = (Transform)Instantiate(customer, my_tranform.position, Quaternion.identity);
            customer c = customer_.GetComponent<customer>();
            c.Init(this, customer_count);
            q1.Enqueue(c.gameObject);
            number = q1.Count - 1;
            c.waiting_point = waiting_point[0];
            c.waiting_number = q1.Count;
            spawn = false;
        }
        //customer_ = (Transform)Instantiate(customer, my_tranform.position, Quaternion.identity);
        //customer c = customer_.GetComponent<customer>();
        //c.Init(this, customer_count);
        //q1.Enqueue(c.gameObject);
        //number = q1.Count - 1;
        //c.waiting_point = waiting_point[number];
        //c.waiting_number = q1.Count;

        //if (bookpoint_is_empty)
        //{
        //    if(c.waiting_number == 1)
        //    {
        //        c.waiting_point = booking_point;
        //        bookpoint_is_empty = false;


        //    }

        //}
        //else
        //{
        //    c.waiting_point = waiting_point[q1.Count -2];
        //}


        //}
        //if (seat1)
        //{
        //    customer c = customer_.GetComponent<customer>();
        //    number -= 2;
        //    c.waiting_point = waiting_point[number];
        //}

    }
    
}
