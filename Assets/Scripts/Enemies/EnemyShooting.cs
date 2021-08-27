using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public bool onRange = false;
    Transform player;
    public float bulletForce = 20f;
    public Rigidbody projectile;

    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Shoot()
    {

        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletForce, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (onRange)
        {
            transform.LookAt(player);
        }
    }
}
