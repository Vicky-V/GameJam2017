using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public float horizontalSpeed = 5.0f;
    public float jumpForce = 20.0f;
   
    void OnTriggerEnter(Collider collider)
    {
        //if (collider.tag == "Obstacle")
      //      Jump();

    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Acceleration);
    }
}
