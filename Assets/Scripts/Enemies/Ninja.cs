using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy, ISlime
{
    private bool isInvisible;
    private MeshRenderer mesh;
    private List<Collider> spikesColliding = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spikes")
        {
            spikesColliding.Add(other);
            isInvisible = true;
            mesh.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spikes")
        {
            spikesColliding.Remove(other);

            if (spikesColliding.Count == 0)
            {
                isInvisible = false;
                mesh.enabled = true;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (!isInvisible)
        {
            slimeHealth.ApplyDamage(amount);
            CheckForDeath();
        }
    }
}
