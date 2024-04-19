using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class BildableObject : MonoBehaviour
{
    
    public enum BuildStates
    {
        Available,
        Rejected,
    }

    public BuildStates currentBuildState;

    public Color buildAvailable;
    public Color buildRejected;

    private Image shopItemBar;
    private BoxCollider buildingCollider;
    private Transform buildCenter;

    public float fill;
    
    


    private void Start()
    {
        buildingCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        buildCenter = GetComponentInParent<Transform>();
        Collider[] objectsInBuildZone = Physics.OverlapBox(buildCenter.transform.position, buildingCollider.size);
        List<GameObject> buildingsInZone = new List<GameObject>();
        foreach (Collider obj in objectsInBuildZone) 
        {
            if (obj.TryGetComponent<BildableObject>(out BildableObject building))
            {
                buildingsInZone.Add(building.gameObject);    
            }
           
        }
       
        if (buildingsInZone.Count > 2)
        {
            currentBuildState= BuildStates.Rejected;
            gameObject.GetComponent<MeshRenderer>().material.color=buildRejected;
        }
        else
        {
            currentBuildState= BuildStates.Available;
            gameObject.GetComponent<MeshRenderer>().material.color = buildAvailable;
        }

        if (shopItemBar != null)
        {
            shopItemBar.fillAmount = fill;
        }
        

        if (fill >= 1)
        {
            BildingSystem.Instance.buildingObject = gameObject.transform.parent.gameObject;
            BildingSystem.Instance.buildingInProces= true;
            shopItemBar.fillAmount = 0;
        }
    }

    public bool CanBeBuilded()
    {
        
        return currentBuildState == BuildStates.Available;
        
    }

    public void Fill(float fillAmmount)
    {
        shopItemBar = ShopItemBar.GetBar();
        fill += fillAmmount;
    }
}

