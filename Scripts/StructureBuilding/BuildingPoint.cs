using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingPoint : MonoBehaviour
{
    [SerializeField] private StructureType structureType;

    public StructureType GetStructureType()
    {
        return structureType;
    }
}

public enum StructureType
{
    Foudation,
    Wall,
    Celing,
    Door,
    Window
}