using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopForniture", menuName = "Data/ShopFornitureSO")]
public class ShopFornitureSO : ScriptableObject
{
    
    public List<ShopForniture> shelfs;
    public List<ShopForniture> bookShelfs;
}
[System.Serializable]
public class ShopForniture
{
    public GameObject objects;
   
}


