using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{
    public GameObject Hat;
    public GameObject Head;
    public float verticalSensitivity = 1.0f;
    public Bone rootBone;
    
    void Start()
    {
        StartCoroutine(SetBonePosition());

    }

    void Update()
    {
       // transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0) * verticalSensitivity;
        Hat.transform.position = Head.transform.transform.position;
    }

    IEnumerator SetBonePosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.15f);
            rootBone.TargetWorldYPos = Hat.transform.position.y;

        }
    }
}
