using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawAimLine : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 hitPoint;
    private LineRenderer lr;
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {
         //if(hit.collider.tag == "balls" || hit.collider.tag == "sideBumpers")
            //{
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, hit.point);
            //}  
        }
    }
}
