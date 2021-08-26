using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{

    Ray myRay;      // initializing the ray
    RaycastHit hit; // initializing the raycasthit
    public GameObject objectToinstantiate;

    public NavMeshSurface surface;
    public NavMeshSurface ninjaSurface;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Clicked();
            surface.BuildNavMesh();
            ninjaSurface.BuildNavMesh();
        }
    }

    void Clicked()
    {
        myRay = Camera.main.ScreenPointToRay(Input.mousePosition); 
        if (Physics.Raycast(myRay, out hit))
        { 
                Instantiate(objectToinstantiate, hit.point+new Vector3(0,0.5f,0), Quaternion.identity);
                Debug.Log(hit.point);
        }
}
}
