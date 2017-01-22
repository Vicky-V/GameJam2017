using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    public float StartForce;
    public float LifeTime;
    
    public void Shoot()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * StartForce, ForceMode.Impulse);

    }

    void Update()
    {
        LifeTime -= Time.deltaTime;

        if (LifeTime < 0)
            Destroy(gameObject);
    }
}
