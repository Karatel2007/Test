using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingStructureDataBase", menuName = "Data/BuildingStructureDataBase")]
public class BuildingStructureDataBase : ScriptableObject
{
    public List<BuildingStructureSO> structureBuildingData;

}
