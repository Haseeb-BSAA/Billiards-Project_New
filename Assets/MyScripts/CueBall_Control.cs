using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall_Control : MonoBehaviour
{

    private Rigidbody rb;
    public float force;
    public float torque;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.AddForceAtPosition(-transform.forward * force, transform.position, ForceMode.Impulse);
        }

    }
}
