using UnityEngine;
using System.Collections;

public class Bone : MonoBehaviour
{
    float targetWorldYPos;
    public float TargetWorldYPos
    {
        get { return targetWorldYPos; }
        set { targetWorldYPos = value; previousWorldYPos = transform.position.y; timePassed = 0.0f; }
    }

    float previousWorldYPos;
    float timePassed;

    const float speed = 0.2f;


    void Start()
    {
        previousWorldYPos = 0.0f;
        timePassed = speed;
        previousWorldYPos = targetWorldYPos;
    }

    // Update is called once per frame
    void Update ()
    {
        //if (transform.GetSiblingIndex() > 0)
        //{
        //    transform.forward = transform.parent.GetChild(transform.GetSiblingIndex() - 1).position - transform.position;
        //    transform.Rotate(-90, 0, 0);
        //}

        timePassed += Time.deltaTime;

        if (timePassed >= speed)
        {
            previousWorldYPos = targetWorldYPos;
            timePassed = speed;
            transform.position = new Vector3(transform.position.x, targetWorldYPos, transform.position.z);

        }
        else
        {
            float yPos = Mathf.Lerp(previousWorldYPos, targetWorldYPos, timePassed / speed);
            transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        }
        
        if ( timePassed > speed/2)
        {
            if (transform.parent.childCount > transform.GetSiblingIndex() + 1 && transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Bone>()!=null)
                transform.parent.GetChild(transform.GetSiblingIndex() + 1).GetComponent<Bone>().TargetWorldYPos = targetWorldYPos;
        }
    }
}
