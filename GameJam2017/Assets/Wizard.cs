using UnityEngine;
using System.Collections;

public class Wizard : AIController
{
    public GameObject world;

    void Update()
    {
        world.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnDestroy()
    {
        if(Game.Instance!=null)
            Game.Instance.GameOver();
    }

}
