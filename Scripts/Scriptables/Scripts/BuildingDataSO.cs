using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data/BuildingData")]
public class BuildingDataSO : ScriptableObject
{
    public List<BuildingInfo> BuildingsInfo;
}

[System.Serializable]
public class BuildingInfo
{
    public string name;
    public GameObject hologram;
    public int price;


}