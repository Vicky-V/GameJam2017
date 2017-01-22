using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public float horizontalSpeed = 5.0f;
    public float jumpForce = 20.0f;

    bool isJumping = false;
   
    void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Obstacle")
            Jump();

    }

    void Jump()
    {
        GetComponent<Rigidbody>().drag = 5;
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        isJumping = true;
    }
   
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        GetComponent<Rigidbody>().drag = 0;
    }
}
