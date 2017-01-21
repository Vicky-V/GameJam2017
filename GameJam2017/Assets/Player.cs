using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    
    public float verticalSensitivity = 1.0f;
    public float horizontalSpeed = 20.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Time.deltaTime* horizontalSpeed, Input.GetAxis("Vertical"), 0) * verticalSensitivity;

    }
}
