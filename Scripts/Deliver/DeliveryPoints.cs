using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoints : MonoBehaviour
{
    public static DeliveryPoints Instance { get; private set; }
    [SerializeField] private List<GameObject> points;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more then one DeliveryPoints");
        }
        Instance = this;
    }

    public List<GameObject> GetPointList()
    {
        return points;
    }

}
