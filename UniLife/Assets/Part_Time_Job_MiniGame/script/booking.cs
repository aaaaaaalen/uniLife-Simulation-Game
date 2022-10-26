using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booking : MonoBehaviour
{
    //public GameObject customer_script;
    public int number;
    private Ray ray;
    private GameObject obj;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        //customer_script = GameObject.FindGameObjectWithTag("customer");
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    customer cc = customer_script.GetComponent<customer>();
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        obj = hit.collider.gameObject;
        //        if (obj.tag == "booking_table" && cc.waiting_number == number)
        //        {
                    
        //            cc.agent.SetDestination(cc.seat_point[0].transform.position);

        //        }

        //    }
        //}
        
    }
    private void OnTriggerEnter(Collider other)
    {
    //    if(other.gameObject.tag == "customer")
    //    {
    //        customer cc = customer_script.GetComponent<customer>();
           
    //        number = cc.getWaiting_Number();
    //        Debug.Log(number);
    //    }
    }
}
