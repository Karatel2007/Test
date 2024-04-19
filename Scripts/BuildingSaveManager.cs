using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSaveManager : MonoBehaviour, ISaveable
{
    public static BuildingSaveManager Instance { get; private set; }

    [SerializeField] private BuildingStructureDataBase structureData;

    private List<Structure> structures = new List<Structure>();
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one BuildingSaveManager");
        }
        Instance = this;
    }
    private void Start()
    {
        Load();
        SaveManager.Instance.AddNewSaveable(this);
    }
    public void AddStucture(Structure newStucture)
    {
        structures.Add(newStucture);
    }

    public void RemoveStructures(Structure structure)
    {
        structures.Remove(structure);
    }

    public void Save()
    {
        for (int i = 0; i < structures.Count; i++)
        {
            ES3.Save("structureSO" + i, structures[i].GetBuildingStructureSO());
            ES3.Save("structureTrns" + i, structures[i].transform);
        }
        ES3.Save("LevelStructures", structures.Count);
    }

    public void Load()
    {
        int structureCount = ES3.Load<int>("LevelStructures");

        for (int i = 0; i < structureCount; i++)
        {
            BuildingStructureSO buildingData = ES3.Load<BuildingStructureSO>("structureSO");
            Transform structureTransform = ES3.Load<Transform>("structureTrns");
            Instantiate(buildingData, structureTransform.position, structureTransform.rotation);
        }
    }
}
