using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResoursesSpaner : MonoBehaviour
{
    [SerializeField]private ShopDataSO shopdData;

    public void Products(int id)
    {
        
            for (int i = 0; i < 3; i++)
            {
                Instantiate(shopdData.items[id].prefab, transform.position, Quaternion.identity);
            }
        
        
        
    }
}
