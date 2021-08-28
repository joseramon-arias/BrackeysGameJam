using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gunner : Enemy, ISlime
{
    // Shoot Logic Variables
    private bool onRange = false;
    private float bulletForce = 20f;
    [SerializeField] private Rigidbody projectile;

    // Movement Logic Variables
    [SerializeField] private float distThreshold;

    // Follow Player Logic Variables
    //private Enemy movementScript;

    // Start is called before the first frame update
    void Start()
    {
        slimeHealth = GetComponent<Health>();
        //movementScript = GetComponent<Enemy>();

        // Shoot Variables Init
        float rand = Random.Range(1.0f, 2.0f);
        InvokeRepeating("Shoot", 2, rand);
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
        // Point towards player if shooting
        if (onRange)
        {
            transform.LookAt(player.transform);
        }
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= distThreshold)
        {
            MoveStatus = false;
            //movementScript.MoveStatus = false;
            onRange = true;
        }
        else if (dist > distThreshold)
        {
            MoveStatus = true;
            //movementScript.MoveStatus = true;
            onRange = false;
        }
    }

    // Fire a missile
    void Shoot()
    {
        if (onRange)
        {

            Rigidbody bullet = (Rigidbody)Instantiate(projectile, transform.position + transform.forward, transform.rotation);
            bullet.AddForce(transform.forward * bulletForce, ForceMode.Impulse);

            Destroy(bullet.gameObject, 2);
        }
    }

    public void TakeDamage(int amount)
    {
        slimeHealth.ApplyDamage(amount);
        CheckForDeath();
    }
}
