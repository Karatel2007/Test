using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private CarController carController;
    private BodyTilt bodyTilt;

    public CinemachineVirtualCamera virtualCamera;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform exitPoint;

    private bool isDriving;
    private void Start()
    {
        carController = GetComponent<CarController>();
        bodyTilt= GetComponent<BodyTilt>();
        carController.enabled = false;

        PlayerInputs.Instance.OnPlayerSecondInteract += PlayerInputs_OnPlayerSecondInteract;
    }

    private void PlayerInputs_OnPlayerSecondInteract(object sender, System.EventArgs e)
    {
        if (isDriving)
        {
            ExitTheCar();
        }
    }

 
    public void EnterTheCar()
    {
        carController.enabled = true;
        bodyTilt.enabled = true;
        virtualCamera.Priority = 100;
        Destroy(PlayerController.Instance.gameObject, 1);
        isDriving= true;
    }
    public void ExitTheCar() 
    {
        Instantiate(playerPrefab, exitPoint.position, Quaternion.identity);
        bodyTilt.enabled = false;
        carController.enabled = false;
        virtualCamera.Priority = 0;   
        isDriving= false;
    }
}
