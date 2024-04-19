using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyerSpawner : MonoBehaviour
{
    public static BuyerSpawner Instance { get; private set; }

    private GameObject buyerForSpawn;

    public PeopleData buyerData;
    public bool buyerOnLevel = false;
    private GameObject spawnedBuyer;

    private bool shopIsWorking = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more tahan one PlayerController");
        }
        Instance = this;
    }

    private void Update()
    {
        if (shopIsWorking && !buyerOnLevel)
        {
            SpawnBuyer();
        }
    }

    public void StartWorkProces()
    {
        shopIsWorking = true;     
    }
    public void StopWorkProces()
    {
        shopIsWorking = false;     
    }

    public void DestroyBuyer()
    {
        Destroy(spawnedBuyer);
        buyerOnLevel = false;
    }

    public void SpawnBuyer()
    {
        int carIndex = Random.Range(0, buyerData.objects.Length);
        int materialIndex = Random.Range(0, buyerData.materials.Length);
        buyerForSpawn = buyerData.objects[carIndex];
        spawnedBuyer = Instantiate(buyerForSpawn, transform.position, transform.rotation);
        spawnedBuyer.GetComponentInChildren<SkinnedMeshRenderer>().material = buyerData.materials[materialIndex];   
        buyerOnLevel = true;
    }
}
