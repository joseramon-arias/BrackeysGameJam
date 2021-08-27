using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunnerController : MonoBehaviour
{
    public GameObject player;
    public float distThreshold;
    FollowPlayer movementScript;
    bool movScriptActivated = false; 
    EnemyShooting shootLogic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        movementScript = GetComponent<FollowPlayer>();
        shootLogic = GetComponent<EnemyShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist <= distThreshold)
        {
            movementScript.MovementStatus(false);
            shootLogic.onRange = true;
        } 
        else if (dist > distThreshold)  
        {
            movementScript.MovementStatus(true);
            shootLogic.onRange = false;
        }
    }
}
