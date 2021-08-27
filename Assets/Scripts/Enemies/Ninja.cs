using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy, ISlime
{
    private bool isInvisible;
    private MeshRenderer mesh;

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
        Debug.Log("WAAAA");
        if (other.tag == "Spikes")
        {
            isInvisible = true;
            mesh.enabled = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spikes")
        {
            isInvisible = false;
            mesh.enabled = true;
        }
    }

    public void TakeDamage()
    {
        if (!isInvisible)
        {
            slimeHealth.ApplyDamage(hitDamage);
        }
    }
}
