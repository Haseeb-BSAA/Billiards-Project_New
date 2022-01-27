using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private Rigidbody rb;
    public float torque;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb = GetComponent<Rigidbody>();
    }

     void Update()
    {
        


    }

     void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "sideBumpers")
        {
            Debug.Log("doned");
            Vector3 direction = Vector3.Cross(collision.relativeVelocity, Vector3.up);
            rb.AddTorque(-direction);
        }
        if(collision.gameObject.tag == "cueBall" || collision.gameObject.tag == "balls")
        {
            if (gameObject.tag != "cueBall")
            {
                Vector3 direction = collision.gameObject.transform.position - transform.position;
                Vector3 normalDir = Vector3.Cross(direction, Vector3.up);
                //rb.AddTorque(normalDir * collision.relativeVelocity.magnitude);
                //rb.AddForceAtPosition(direction, transform.position);
            }
        }

    }

    }



