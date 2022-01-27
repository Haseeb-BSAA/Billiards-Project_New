using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCueBall : MonoBehaviour
{
    private Vector3 offset;
    [SerializeField]
    private GameObject cueBall;
    // Start is called before the first frame update
    void Start()
    {
        offset = cueBall.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(cueBall.transform.position.x - offset.x,transform.position.y, cueBall.transform.position.z - offset.z);
    }
}
