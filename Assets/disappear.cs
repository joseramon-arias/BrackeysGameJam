using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear : MonoBehaviour
{
    MeshRenderer thisMesh;
    // Start is called before the first frame update
    void Start()
    {
        thisMesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 1.7)
        {
            thisMesh.enabled = false;
        }
        else
        {
            thisMesh.enabled = true;
        }
    }
}
