using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{

    public float verticalSensitivity = 1.0f;
    public Bone rootBone;
    
    void Start()
    {
        StartCoroutine(SetBonePosition());

    }

    void Update()
    {
        transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0) * verticalSensitivity;

    }

    IEnumerator SetBonePosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.15f);
            rootBone.TargetWorldYPos = transform.position.y;

        }
    }
}
