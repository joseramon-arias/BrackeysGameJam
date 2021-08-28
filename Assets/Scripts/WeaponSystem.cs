using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public List<GameObject> currentWeapon; 
    public WeaponModule[] possibleModules;
    public Transform edgeModule;

    private void Start()
    {
        currentWeapon = new List<GameObject>();
        GameObject module = Instantiate(possibleModules[0].prefab, transform);
        currentWeapon.Add(module);
        edgeModule = module.transform;
    }

    //=========================
    //
    // UPDATE - DEBUG CONTROLS
    //
    //=========================
    public void Update()
    {
        //Add random module
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (possibleModules != null)
            {
                int randomModule = Mathf.RoundToInt(UnityEngine.Random.Range(0, possibleModules.Length));
                AddModule(randomModule);
            }
            else return;
        }

        //Delete edge module
        if (Input.GetKeyDown(KeyCode.X))
        {
            RemoveLastModule();
        }

        if (Input.inputString != "")
        {
            int number;
            bool isNumber = Int32.TryParse(Input.inputString, out number);
            if (isNumber && number >= 0 && number < 10)
            {
                Debug.Log("Pressed number: " + number);
                RemoveModule(number);
            }
        }
    }
    public void AddModule(int moduleType)
    {
        Transform slot = edgeModule.GetChild(0).transform;
        GameObject module = Instantiate(possibleModules[moduleType].prefab, slot);
        currentWeapon.Add(module);
        edgeModule = module.transform;
    }

    public void RemoveLastModule()
    {
        RemoveModule(currentWeapon.Count-1);
    }

    public void RemoveModule(int index)
    {
        if (!currentWeapon[index] || index < 0) return;
        if (index >= currentWeapon.Count) index = currentWeapon.Count - 1;

        //if not removing edge module, it needs to reparent the following modules
        if (index != currentWeapon.Count - 1)
        {
            Transform attModule = currentWeapon[index+1].transform;
            Transform parentModule = attModule.parent.parent.parent; //parent three times because it's a slot inside an object and a prefab
            attModule.SetParent(parentModule);
            attModule.localPosition = Vector3.zero;
            attModule.localRotation = Quaternion.identity;
        }
        GameObject module = currentWeapon[index];
        currentWeapon.RemoveAt(index);

        edgeModule = currentWeapon[currentWeapon.Count - 1].transform;

        Destroy(module);
    }

    public void InsertModule(int index)
    {
        //
    }
}
