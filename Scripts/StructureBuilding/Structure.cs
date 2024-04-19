using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour
{
    [SerializeField] private StructureType type;
    [SerializeField] private BuildingStructureSO structureSO;

    private void Start()
    {
        BuildingSaveManager.Instance.AddStucture(this);
    }

    public StructureType GetStructureType() 
    { 
        return type; 
    }
    
    public BuildingStructureSO GetBuildingStructureSO()
    {
        return structureSO;
    }
}