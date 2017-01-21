using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{
    public float sensitivity = 1.0f;
    public Bone rootBone;

    bool isAscending;

    void Start()
    {
        StartCoroutine(SetBonePosition());

    }

    // Update is called once per frame
    void Update () {
        transform.position += new Vector3(0, Input.GetAxis("Vertical"), 0)*sensitivity;

        isAscending = Input.GetAxis("Vertical") > 0;

	}
    
    IEnumerator SetBonePosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.25f);
            rootBone.TargetWorldYPos = transform.position.y;

        }
    }
}
