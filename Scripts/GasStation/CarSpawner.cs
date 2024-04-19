using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    public static CarSpawner Instance { get; private set; }

    private GameObject carForSpawn;

    public PullData pullData;
    public bool carOnLevel = false;
    private GameObject spawnedCar;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more tahan one PlayerController");
        }
        Instance = this;
    }

    public void StartWorkProces()
    {
        SpawnCar();
    }

    public void DestroyCar()
    {
        Destroy(spawnedCar);
        carOnLevel = false;
    }

    public void SpawnCar()
    {
        int carIndex = Random.Range(0, pullData.objects.Length);
        int materialIndex = Random.Range(0, pullData.materials.Length);
        carForSpawn = pullData.objects[carIndex];
        spawnedCar = Instantiate(carForSpawn, transform.position, transform.rotation);
        spawnedCar.GetComponent<MeshRenderer>().material = pullData.materials[materialIndex];
        carOnLevel= true;
    }
}
