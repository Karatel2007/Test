using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class BuildingMenu : MonoBehaviour
{
    [SerializeField] private BuildingDataSO buildingData;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private GameObject parent;

    private bool isOpen;

    private void Start()
    {
        GenerateButtons();

        PlayerInputs.Instance.OnBuildingMenuOpen += PlayrInputs_OnBuildingMenuOpen;
    }

    private void PlayrInputs_OnBuildingMenuOpen(object sender, System.EventArgs e)
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            OpenMenu();
        }
        else
        {
            HideMenu();
        }
    }

    private void GenerateButtons()
    {
        foreach (BuildingInfo item in buildingData.BuildingsInfo)
        {

            GameObject spawnedButton = Instantiate(buttonPrefab, parent.transform);
            spawnedButton.GetComponentInChildren<TextMeshProUGUI>().text = item.name;
            spawnedButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                StructureBuilding.Instance.BuildStructure(item);
                HideMenu();
            });

          
        }
    }

    private void OpenMenu()
    {
        parent.SetActive(true);
        StructureBuilding.Instance.EndBuilding();
        Cursor.lockState = CursorLockMode.Confined;


    }
    private void HideMenu()
    {
        isOpen = false;
        parent.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
