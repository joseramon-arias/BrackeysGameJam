using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Unity.AI.Navigation;
using UnityEngine;

public partial class CreateArenaDummy : MonoBehaviour
{
    [SerializeField] private NavMeshSurface humanoidSurface;
    [SerializeField] private NavMeshSurface ninjaSurface;

    void Start()
    {
        humanoidSurface.BuildNavMesh();
        ninjaSurface.BuildNavMesh();
    }
}
