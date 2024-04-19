using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryBoxSpawn : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private float coulDown;
    [SerializeField] private BoxCollider boxCollider;
    private float timer = 0f;
    private bool placeIsFree = true;
    
    private void Update()
    {
        if (placeIsFree)
        {
            timer += Time.deltaTime;
        }
        if (timer >= coulDown)
        {
            SpawnBox();
            timer= 0f;
        }
        if (timer == 0f)
        {
            Collider[] item =  Physics.OverlapBox(transform.position, boxCollider.size / 2);
            if(item.Length < 2)
            {
                FreeUpPlace();
            }
            
            
        }
    }
    public void SpawnBox()
    {
        Instantiate(boxPrefab, transform.position, Quaternion.identity);
        placeIsFree = false;
    }
    public void FreeUpPlace()
    {
        placeIsFree = true; 
    }
}
