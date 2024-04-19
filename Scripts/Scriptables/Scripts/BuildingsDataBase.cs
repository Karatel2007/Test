using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuyShopItemData", menuName = "Data/BuyShopItemData")]
public class BuildingsDataBase : ScriptableObject
{
    public List<BuildingData> buildingsList = new List<BuildingData>();
}
