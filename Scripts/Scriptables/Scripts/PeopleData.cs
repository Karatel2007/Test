using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PeopleData", menuName = "Data/PeopleData")]
public class PeopleData : ScriptableObject
{
    public GameObject[] objects;
    public Material[] materials;
}
