using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{
    public Bone rootBone;
    
    void Start()
    {
        StartCoroutine(SetBonePosition());

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
