using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopData", menuName = "Data/ShopData")]
public class ShopDataSO : ScriptableObject
{ 
    public List<ShopItem> items;
}
[System.Serializable]
public class ShopItem  
{
    public int index;
    public int price;
    public Sprite icon;
    public GameObject prefab;
}
