using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamikaze : Enemy, ISlime
{
    // Start is called before the first frame update
    void Start()
    {
        MoveStatus = true;
    }

    // Update is called once per frame
    override public void Update()
    {
        base.Update();
        //movementScript.MoveStatus = false;
    }

    public void TakeDamage(int amount)
    {
        slimeHealth.ApplyDamage(amount);
        CheckForDeath();
    }
}
