using UnityEngine;
using System.Collections;

public class Wizard : AIController
{
    public GameObject world;

    void Update()
    {
        world.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
            base.OnCollisionEnter(collision);
        else
            Destroy(gameObject);

    }

    void OnDestroy()
    {
        if(Game.Instance!=null)
            Game.Instance.GameOver();
    }

}
