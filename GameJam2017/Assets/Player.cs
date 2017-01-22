using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject BulletPrefab;
    public GameObject Weapon;
    public GameObject WeaponSpawnPoint;
    public float horizontalSpeed = 20.0f;
    public float jumpForce = 20.0f;
    public float fireDelay;

    float currentFireDelay;

    bool isJumping=false;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10.0f;
        Vector3 dir = Camera.main.ScreenToWorldPoint( mousePos)- Weapon.transform.position;
        dir = Vector3.ProjectOnPlane(dir, transform.right);
        Debug.DrawLine(Weapon.transform.position, Weapon.transform.position + dir);

        Weapon.transform.rotation = Quaternion.FromToRotation(transform.up, dir);

        if (currentFireDelay > 0.0f)
            currentFireDelay -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && currentFireDelay <= 0)
            Shoot();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody>().AddForce(transform.right * Input.GetAxis("Horizontal") * horizontalSpeed, ForceMode.Force);

        if (Input.GetButtonDown("Jump") && !isJumping)
            Jump();
    }

    void Jump()
    {
        GetComponent<Rigidbody>().AddForce(transform.up * jumpForce, ForceMode.Acceleration);
        isJumping = true;
    }

    void Shoot()
    {
        currentFireDelay = fireDelay;
        GameObject bullet = Instantiate(BulletPrefab,WeaponSpawnPoint.transform.position, WeaponSpawnPoint.transform.rotation) as GameObject;
        bullet.GetComponent<Projectile>().Shoot();
    }

    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }
}
