using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour
{
    public float acceleration = 5.0f;
    public float maxSpeed = 20.0f;
    public float jumpForce = 20.0f;

    protected bool isJumping = false;

    void Start()
    {
        GetComponent<Rigidbody>().drag = 0;
    }
   
    protected virtual void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Obstacle")
            Jump();

    }

    protected virtual void FixedUpdate()
    {
       // if(!isJumping)
            GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * acceleration * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Finish")
            Destroy(this.gameObject);
    }

    protected virtual void Jump()
    {
        GetComponent<Rigidbody>().drag = 5;
        GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Acceleration);
        isJumping = true;
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
        GetComponent<Rigidbody>().drag = 0;
    }
}
