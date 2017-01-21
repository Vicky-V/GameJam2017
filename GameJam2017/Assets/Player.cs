using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float horizontalSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime* horizontalSpeed, 0, 0);

    }

    void Jump()
    {

    }
}
