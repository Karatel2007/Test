using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeliveryBox : MonoBehaviour
{
    public GameObject deliveryDestination;
    private int price;

    private void Start()
    {
        FindDeliveryPoint();
        
    }
    public void StartWork()
    {
        deliveryDestination.SetActive(true);
        PlayerController.Instance.GetComponent<Deliver>().SetDeliveryDestination(deliveryDestination.transform);
    }
    public void EndWork()
    {
        PlayerController.Instance.GetComponent<Deliver>().StopWorked();
    }
    private void FindDeliveryPoint()
    {
        List<GameObject> delveryPoints = DeliveryPoints.Instance.GetPointList();
        deliveryDestination = delveryPoints[Random.Range(0, delveryPoints.Count - 1)];
    }
    public int DeliveringBoxPrice()
    {
        price = Random.Range(0, 300);
        return price;
    }
}
