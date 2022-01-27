using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueStick : MonoBehaviour
{

    public float rotateSpeed;
    [SerializeField]
    private float strikeForce;
    [SerializeField]
    public Vector3 offset;
    [SerializeField]
    public Transform cueBall;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float retreatSpeed;
    public bool aboutToShoot;
    [SerializeField]
    public GameObject cueHolder;
    private bool isMoving;
    public Vector3 startingPostion;
    public Quaternion startingRotation;
    public bool retreating;
    public bool firstShot;
    public bool playedShot;
    public int shootCount;
    public GameObject[] balls;
    public GameObject[] tableParts;
    public int numberOfTableParts;
    public int numberOfBalls;
    private Rigidbody rb;
    [SerializeField]
    GameObject cueStickClone;
    public bool resetPosition;
    public Transform rotatePoint;
    void Start()
    {
        resetPosition = false;
        shootCount = 0;
        playedShot = false;
        firstShot = true;
        retreating = false;
        isMoving = false;
        aboutToShoot = false;
        rb = gameObject.GetComponent<Rigidbody>();
        for (int i = 0; i < numberOfBalls; i++)
        {
            Physics.IgnoreCollision(balls[i].gameObject.GetComponent<SphereCollider>(), gameObject.GetComponent<MeshCollider>());
        }
        for (int i = 0; i < numberOfTableParts; i++)
        {
            Physics.IgnoreCollision(tableParts[i].gameObject.GetComponent<MeshCollider>(), gameObject.GetComponent<MeshCollider>());
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playedShot = false;
            aboutToShoot =  true;
        }

        if (aboutToShoot)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                rb.velocity = -transform.right.normalized * strikeForce;
                aboutToShoot = false;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(rotatePoint.position + offset, rotatePoint.up, Time.deltaTime * rotateSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(rotatePoint.position + offset, -rotatePoint.up, Time.deltaTime * rotateSpeed);
            transform.RotateAround(rotatePoint.position + offset, -rotatePoint.up, Time.deltaTime * rotateSpeed);
        }

        if(resetPosition && shootCount > 0 && cueBall.GetComponent<Rigidbody>().angularVelocity.x == 0 && cueBall.GetComponent<Rigidbody>().angularVelocity.z == 0)
        {
            transform.localPosition = cueStickClone.transform.localPosition;
            transform.localRotation = cueStickClone.transform.localRotation;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            resetPosition = false;
            //Debug.Log("I am here");
        }

    }

    void FixedUpdate()
    {

        if (aboutToShoot)
        {
            gameObject.GetComponent<MeshCollider>().enabled = true;
            rb.velocity = (transform.right * moveSpeed * Time.deltaTime);
        }
        if (retreating)
        {
            rb.velocity = (transform.right * retreatSpeed * Time.deltaTime);
            StartCoroutine(RetreatAfterHit());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cueBall")
        {
            //Debug.Log("detected");
            shootCount++;
            //gameObject.GetComponent<MeshCollider>().enabled = false;
            //rb.isKinematic = true;
            //rb.isKinematic = false;
            retreating = true;
            playedShot = true;
        }
    }

    IEnumerator RetreatAfterHit()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        retreatSpeed += 3;
        yield return new WaitForSecondsRealtime(1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        retreating = false;
        resetPosition = true;
        rb.isKinematic = true;
        rb.isKinematic = false;
        retreatSpeed -= 3;
    }
}
