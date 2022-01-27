using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueHolderClone : MonoBehaviour
{

   
    public GameObject[] balls;
    public GameObject[] tableParts;
    public int numberOfTableParts;
    public int numberOfBalls;
    public GameObject cueHolder;
    public GameObject cueStick;
    // Start is called before the first frame update


    void Start()
    {
        for (int i = 0; i < numberOfBalls; i++)
        {
            Physics.IgnoreCollision(balls[i].gameObject.GetComponent<SphereCollider>(), gameObject.GetComponent<MeshCollider>());
        }
        for (int i = 0; i < numberOfTableParts; i++)
        {
            Physics.IgnoreCollision(tableParts[i].gameObject.GetComponent<MeshCollider>(), gameObject.GetComponent<MeshCollider>());
        }
        Physics.IgnoreCollision(cueStick.GetComponent<BoxCollider>(), gameObject.GetComponent<MeshCollider>());
        Physics.IgnoreCollision(cueHolder.GetComponent<MeshCollider>(), gameObject.GetComponent<MeshCollider>());
    }

    void Update()
    {

    }
}
