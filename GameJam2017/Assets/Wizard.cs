using UnityEngine;
using System.Collections;

public class Wizard : AIController
{
    public GameObject world;

    void Update()
    {
        world.transform.position = new Vector3(transform.position.x, world.transform.position.y, transform.position.z);
    }

    protected void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(transform.position + transform.forward * horizontalSpeed*Time.deltaTime);
    }

}
