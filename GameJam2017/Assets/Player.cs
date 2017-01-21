using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float horizontalSpeed = 20.0f;
    public float jumpForce = 20.0f;

    bool isJumping=false;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalSpeed, ForceMode.Force);

        if (Input.GetButtonDown("Jump") && !isJumping)
            Jump();
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Acceleration);
        isJumping = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
