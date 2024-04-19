using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BildingSystem : MonoBehaviour
{
    public static BildingSystem Instance { get; private set; }

    public BuildingsDataBase buildingsDataBase;
    public LayerMask bildableLayers;
    public GameObject buildingObject;

    public bool buildingInProces = false;

    private int turnSpeed = 1530;

    [SerializeField] private Camera rtsCamera;


    BildableObject selectedBiulding;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There are more then one PlayerController");
        }
        Instance = this;
    }

    private void Start()
    {
        PlayerInputs.Instance.OnPlayerMainAction += PlayerInputs_OnPlayerMainAction;
    }

    private void PlayerInputs_OnPlayerMainAction(object sender, EventArgs e)
    {
        if (selectedBiulding != null && selectedBiulding.CanBeBuilded())
        {
            buildingInProces = false;
        }
    }

    private void Update()
    {
        
        if (buildingInProces)
        {

            Ray cameraRay = rtsCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(cameraRay, out RaycastHit hit, float.MaxValue, bildableLayers))
            {
                buildingObject.transform.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
                if (Input.mouseScrollDelta.y > 0)
                {
                    buildingObject.transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);
                    
                }
                if (Input.mouseScrollDelta.y < 0)
                {
                    buildingObject.transform.Rotate(-Vector3.up * turnSpeed * Time.deltaTime);
                }

                selectedBiulding = buildingObject.GetComponentInChildren<BildableObject>();
                

            }
            
        }

    }

    public void BuyBuilding(int id)
    {
        buildingObject = Instantiate(buildingsDataBase.buildingsList[id].prefab);
        DeliveryShop.Instance.furnitures.Add(buildingObject);
        buildingInProces = true;
    }
 

}
