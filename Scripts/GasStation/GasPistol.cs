using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasPistol : MonoBehaviour
{
    private Vector3 pickPosition;
    private Quaternion pickRotation;
    private bool isUsing = false;
    [SerializeField] private float rayLength;
    [SerializeField] private float pickDistance;


    GasHole hole;

    private void Start()
    {
        ProgresBar.Instance.GetBar().gameObject.SetActive(false);

        PlayerInputs.Instance.OnPlayerExitInteract += PlayerInputs_OnPlayerExitInteract;
    }

 

    private void PlayerInputs_OnPlayerExitInteract(object sender, System.EventArgs e)
    {
        if (isUsing || Vector3.Distance(transform.position, pickPosition) > pickDistance && isUsing)
        {
            Put();
        }
    }

    private void Update()
    {

       

        if (isUsing)
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            
            if (Physics.Raycast(ray, out RaycastHit hit, 20f))
            {
               
                if(hit.collider.TryGetComponent(out GasHole hole))
                {
                    ProgresBar.Instance.GetBar().gameObject.SetActive(true);
                    this.hole = hole;
                    
                }
                else
                {
                    ProgresBar.Instance.GetBar().gameObject.SetActive(false);
                }
            }
        }

        if (isUsing && PlayerInputs.Instance.HoldingMainAction())
        {
            hole.FillGas(Time.deltaTime / 10);
        }

    }

    public void Pick(Transform hand)
    {
       
        pickPosition = transform.position;
        pickRotation = transform.rotation;
        isUsing = true;
        transform.SetParent(hand);
        transform.localPosition = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }

    public void Put()
    {
        isUsing = false;
        transform.position = pickPosition;
        transform.rotation = pickRotation;
        transform.SetParent(null);      
        PlayerController.Instance.isHolding = false; 
    }
}
