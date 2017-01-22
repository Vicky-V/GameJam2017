using UnityEngine;
using System.Collections;

public class HeadController : MonoBehaviour
{
    public GameObject Head;
    public GameObject HatRoot;
    public GameObject HatStaticBone;
    public Bone rootBone;
    
    void Start()
    {
        StartCoroutine(SetBonePosition());
        HatRoot.transform.position = transform.position;
    }

    void Update()
    {
        HatRoot.transform.position = new Vector3( transform.position.x, HatRoot.transform.position.y, transform.position.z);
        HatStaticBone.transform.position = Head.transform.position;
    }

    IEnumerator SetBonePosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.15f);

            
            rootBone.TargetWorldYPos = rootBone.transform.parent.InverseTransformPoint( Head.transform.position).z;

        }
    }
}
