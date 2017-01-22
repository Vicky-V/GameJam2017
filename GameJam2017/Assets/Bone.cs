using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour
{
    float targetWorldYPos;
    public float TargetWorldYPos
    {
        get { return targetWorldYPos; }
        set { targetWorldYPos = value; previousWorldYPos = transform.localPosition.z; timePassed = 0.0f; }
    }

    float previousWorldYPos;
    float timePassed;

    const float speed = 0.2f;

    void Start()
    {
        TargetWorldYPos = transform.localPosition.z;
        timePassed = speed;
    }

    // Update is called once per frame
    void Update ()
    {
        if (transform.GetSiblingIndex() > 0)
        {
            transform.LookAt(transform.parent.GetChild(transform.GetSiblingIndex() - 1));
         //   transform.Rotate(-90, 0, 0);
        }

        timePassed += Time.deltaTime;

        if (timePassed >= speed)
        {
            previousWorldYPos = targetWorldYPos;
            timePassed = speed;
            transform.localPosition = new Vector3(transform.localPosition.x,  transform.localPosition.y, targetWorldYPos);
        }
        else
        {
            float yPos = Mathf.Lerp(previousWorldYPos, targetWorldYPos, timePassed / speed);
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, yPos);
        }
        
        if ( timePassed > speed/3)
        {
            if (transform.parent.childCount > transform.GetSiblingIndex() + 1 && transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Bone>()!=null)
                transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Bone>().TargetWorldYPos = this.targetWorldYPos;
        }
    }
}
