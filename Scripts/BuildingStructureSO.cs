using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingStructure", menuName = "Data/BuildingStructure")]
public class BuildingStructureSO : ScriptableObject
{
    public string name;
    public GameObject structurePrefab;
}
