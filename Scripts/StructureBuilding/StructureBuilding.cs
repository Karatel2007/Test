using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StructureBuilding : MonoBehaviour
{

    public static StructureBuilding Instance { get; private set; }

    [SerializeField] private Camera mainCamera;
  
   
    [SerializeField] private float buildingRange;
    [SerializeField] private LayerMask buildingLayer;
    [SerializeField] private GameObject notEnoughText;
    
    private bool isBuilding;
    private int currentHologramIndex;
    private Hologram movingHologram;
    private int placingObjectPrice;

    private void Start()
    {
        if (Instance != null)
        {
            Debug.LogError("There are moore than one StructureBuilding");
        }
        Instance = this;

        PlayerInputs.Instance.OnPlayerSecondMainAction += PlayerInputs_OnPlayerSecondMainAction;
        PlayerInputs.Instance.OnPlayerMainAction += PlayerInputs_OnPlayerMainAction;

    }

    private void PlayerInputs_OnPlayerMainAction(object sender, System.EventArgs e)
    {
        if (isBuilding) 
        {
            if (movingHologram.CanBeBuilded())
            {
                if (MoneySystem.Instance.GetMoney() >= placingObjectPrice)
                {
                    MoneySystem.Instance.SpendMoney(placingObjectPrice);
                    Instantiate(movingHologram.GetStructurePrefab(), movingHologram.transform.position, movingHologram.transform.rotation);
                }
                else
                {
                    notEnoughText.SetActive(true);
                    float hideDelay = 3;
                    Invoke("HideText", hideDelay);
                }

            }
        }
        
    }

    private void PlayerInputs_OnPlayerSecondMainAction(object sender, System.EventArgs e)
    {
        if (isBuilding)
        {
            movingHologram.transform.Rotate(Vector3.up * 90);
        }
    }

    private void Update()
    {

        if (isBuilding)
        {
            Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, buildingRange, buildingLayer))
            {

                if (hit.transform.gameObject.TryGetComponent(out BuildingPoint buildingPoint))
                {
                    if (buildingPoint.GetStructureType() == movingHologram.GetStructureType())
                    {
                        movingHologram.transform.position = buildingPoint.transform.position;
                    }
                }
                else if(movingHologram.GetStructureType() == StructureType.Foudation)
                {
                    movingHologram.transform.position = hit.point;
                }

                
                
            }

           
        }
    }
    
    public void BuildStructure(BuildingInfo buildingInfo)
    {
      
            placingObjectPrice = buildingInfo.price;
            isBuilding = true;
            if (movingHologram != null)
            {
                Destroy(movingHologram.gameObject);
            }
            movingHologram = Instantiate(buildingInfo.hologram).GetComponent<Hologram>();
        

    }

    public void EndBuilding()
    {     
        isBuilding = false;
        if (movingHologram != null)
        {
            Destroy(movingHologram.gameObject);
        }
            
    }


    private void HideText()
    {
       
        notEnoughText.SetActive(false);
    }
}
