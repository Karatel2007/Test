using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class ShopZone : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    private bool buyingProcess;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BuyerAgent agent))
        {
            if (!agent.isStopped)
            {
                agent.StopWalking();
                agent.GiveRequest();
                buyingProcess= true;
            }
            
        }
        
    }
    public void CansellButton()
    {
        Collider[] hitColliders = Physics.OverlapBox(collider.transform.position, collider.size / 2);
        if (buyingProcess)
        {
            foreach (Collider obj in hitColliders)
            {          
                if (obj.TryGetComponent(out BuyerAgent agent))
                {
                    agent.CanselPurches();
                    buyingProcess= false;
                }
            }
            
        }
    }
}
