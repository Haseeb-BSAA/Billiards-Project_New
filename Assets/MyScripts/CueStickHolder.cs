using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStickHolder : MonoBehaviour
{

    public float rotateSpeed;
    private Rigidbody rb;
    [SerializeField]
    private float strikeForce;
    [SerializeField]
    public Vector3 offset;
    [SerializeField]
    public Transform cueBall;
    [SerializeField]
    private float moveSpeed;
    public bool aboutToShoot;
    public GameObject[] balls;
    public GameObject[] tableParts;
    public int numberOfTableParts;
    public int numberOfBalls;
    public GameObject cueStick;
    public bool firstShot;
    [SerializeField]
    private GameObject cueBallPositinObject;
    public bool positionReset;
    // Start is called before the first frame update


    void Start()
    {
        positionReset = false;
        firstShot = true;
        for(int i = 0; i<numberOfBalls; i++)
        {
            Physics.IgnoreCollision(balls[i].gameObject.GetComponent<SphereCollider>(), gameObject.GetComponent<MeshCollider>());
        }
        for(int i = 0; i<numberOfTableParts; i++)
        {
            Physics.IgnoreCollision(tableParts[i].gameObject.GetComponent<MeshCollider>(), gameObject.GetComponent<MeshCollider>());
        }

        aboutToShoot = false;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (cueStick.GetComponent<CueStick>().playedShot == true)
        {
            positionReset = true;
        }
        if (positionReset) {
            if (cueBall.GetComponent<Rigidbody>().angularVelocity.x == 0 && cueBall.GetComponent<Rigidbody>().angularVelocity.z == 0 && cueStick.GetComponent<CueStick>().shootCount > 0)
            {
                Debug.Log("enabled back mesh renderer");
                rb.isKinematic = true;
                gameObject.GetComponent<MeshCollider>().enabled = false;
                cueStick.GetComponent<MeshRenderer>().enabled = true;
                transform.position = cueBallPositinObject.transform.position;
                transform.rotation = cueBallPositinObject.transform.rotation;
                cueStick.GetComponent<CueStick>().playedShot = false;
                rb.isKinematic = false;
                gameObject.GetComponent<MeshCollider>().enabled = true;
                positionReset = false;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(cueBall.position + offset, transform.up, Time.deltaTime * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(cueBall.position + offset, -transform.up, Time.deltaTime * rotateSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (firstShot)
        {
            if (collision.gameObject == cueStick)
            {
                //cueStick.GetComponent<Rigidbody>().isKinematic = true;
                //cueStick.GetComponent<BoxCollider>().enabled = false;
            }
            firstShot = false;
        }
    }
}
