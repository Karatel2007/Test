using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deliver : MonoBehaviour
{  
    [SerializeField] private GameObject arrow;

    private Transform deliveryDestination;
    private bool isWorking = false;

    public void Update()
    {
        if(isWorking)
        {
            arrow.SetActive(true);
            Vector3 lookVector = new Vector3(deliveryDestination.transform.position.x,
                                             0,
                                             deliveryDestination.transform.position.z);
            arrow.transform.LookAt(lookVector);
        }
    }
    public void StopWorked()
    {
        deliveryDestination = null;
        isWorking = false;
        arrow.SetActive(false);
    }
    public void SetDeliveryDestination(Transform dest)
    {
        deliveryDestination = dest;
        isWorking = true;
    }

}
