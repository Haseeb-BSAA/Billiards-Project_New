using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick_Control : MonoBehaviour
{
    public GameObject cueBall;
    public GameObject cueStickClone;
    public Transform rotatePoint;
    public GameObject normalPoint;
    public float rotateSpeed;
    public bool resetPosition;
    public int shootCount;
    private Vector3 hitPoint;
    public float gizmoRadius;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        resetPosition = false;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.D))
        {
            normalPoint.transform.RotateAround(rotatePoint.position, rotatePoint.up, Time.deltaTime * rotateSpeed);
            transform.RotateAround(rotatePoint.position, rotatePoint.up, Time.deltaTime * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            normalPoint.transform.RotateAround(rotatePoint.position, -rotatePoint.up, Time.deltaTime * rotateSpeed);
            transform.RotateAround(rotatePoint.position, -rotatePoint.up, Time.deltaTime * rotateSpeed);
        }

        if (resetPosition && shootCount > 0 && cueBall.GetComponent<Rigidbody>().angularVelocity.x == 0 && cueBall.GetComponent<Rigidbody>().angularVelocity.z == 0)
        {
            transform.localPosition = cueStickClone.transform.localPosition;
            transform.localRotation = cueStickClone.transform.localRotation;
            normalPoint.transform.rotation = rotatePoint.transform.rotation;
            resetPosition = false;
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.right), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
            if (hit.collider.tag == "cueBall")
            {
                hitPoint = hit.point;
                if (Input.GetKeyDown(KeyCode.P))
                {
                    StartCoroutine(waitFrames());
                    hit.collider.GetComponent<Rigidbody>().AddForceAtPosition(force * -normalPoint.transform.forward, hit.point, ForceMode.Impulse);
                }
            }
        }
        else
        {
            Debug.DrawRay(transform.position, -transform.TransformDirection(Vector3.right) * 1000, Color.white);
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(hitPoint, gizmoRadius);
    }

    IEnumerator waitFrames()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        shootCount++;
        resetPosition = true;
    }
}
