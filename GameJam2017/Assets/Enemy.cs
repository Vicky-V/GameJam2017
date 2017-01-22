using UnityEngine;
using System.Collections;

public class Enemy : AIController {

    public float intellect;

    bool[] probs;

    void OnEnable()
    {
        intellect = Random.Range(0,11);

        probs = new bool[10];

        for (int i = 0; i < probs.Length; i++)
        {
            probs[i] = i < intellect ? true : false;
        }

    }

    protected override void FixedUpdate()
    {
        if (GetComponent<Rigidbody>().velocity.sqrMagnitude < maxSpeed * maxSpeed)
            GetComponent<Rigidbody>().AddForce(transform.forward * acceleration, ForceMode.Impulse);
    }

    protected override void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Obstacle")
        {
            if (IntellectCheckPassed())
                Jump();
        }
    }

    bool IntellectCheckPassed()
    {
        int randomIndex = Random.Range(0, probs.Length);

        return probs[randomIndex];
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        if (collision.transform.gameObject.layer == LayerMask.NameToLayer("Projectile"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Game.Instance.IncrementCreatures();

        }
    }

}
