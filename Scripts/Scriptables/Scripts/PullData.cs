using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PullData", menuName = "Data/PullData")]
public class PullData : ScriptableObject
{
    public GameObject[] objects;   
    public Material[] materials;
}
