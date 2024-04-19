using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }

    private List<ISaveable> saveableList = new List<ISaveable>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more than one SaveManager");
        }
        Instance = this;
    }



    private void OnApplicationQuit()
    {
        foreach (var saveable in saveableList)
        {
            saveable.Save();
        }
    }


    public void AddNewSaveable(ISaveable saveable)
    {
        saveableList.Add(saveable);
    }
}
