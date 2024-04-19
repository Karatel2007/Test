using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStationWork : MonoBehaviour
{
    //[SerializeField] private CarSpawner carSpawner;

    private void Start()
    {
      
    }
    public void StartWork()
    {
        if (!CarSpawner.Instance.carOnLevel)
        {
            CarSpawner.Instance.StartWorkProces();
           
        }
    }
}
