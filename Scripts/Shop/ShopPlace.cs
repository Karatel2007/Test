using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPlace : MonoBehaviour
{
    public static int itemIndexInCollider=-1;
    public static GameObject itemPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ShopResourse resourse))
        {
            itemIndexInCollider = resourse.index;
            itemPrefab = other.gameObject;
        }

    }
    
    

}
