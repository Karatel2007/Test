using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectsData", menuName = "Data/ObjectsData")]
public class ObjectsSO : ScriptableObject
{
    public List<GameObject> objects;
}
