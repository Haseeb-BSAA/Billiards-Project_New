//using UnityEngine;

//public class TargetLine : MonoBehaviour
//{
//    // Calculate the reflection of a "laser beam" off a clicked object.

//    // The object from which the beam is fired. The incoming beam will
//    // not be visible if the camera is used for this!
//    public Transform gunObj;

//    void Update()
//    {
//        if (Input.GetKey(KeyCode.Space))
//        {
//            RaycastHit hit;
//            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

//            if (Physics.Raycast(ray, out hit))
//            {
//                // Find the line from the gun to the point that was clicked.
//                Vector3 incomingVec = hit.point - gunObj.position;

//                // Use the point's normal to calculate the reflection vector.
//                Vector3 reflectVec = Vector3.Reflect(incomingVec, hit.normal);

//                // Draw lines to show the incoming "beam" and the reflection.
//                Debug.DrawLine(gunObj.position, hit.point, Color.red);
//                Debug.DrawRay(hit.point, reflectVec, Color.green);
//            }
//        }
//    }
//}