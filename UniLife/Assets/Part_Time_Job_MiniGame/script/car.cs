using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    public Transform[] way_point;
    private int currentPoint = 0;
    private Vector3 target;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPoint < way_point.Length)
        {
            target = way_point[currentPoint].position;
            direction = target - transform.position;
            if (direction.magnitude < 1)
            {
                currentPoint++;
            }

        }
        else
        {
            currentPoint = 0;
        }
        transform.LookAt(target);
        transform.Translate(0, 0, 0.5f);
    }
}
