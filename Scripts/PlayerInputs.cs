using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public static PlayerInputs Instance { get; private set; }

    private MainInputAction inputActions;

    public event EventHandler OnPlayerInteract;
    public event EventHandler OnPLayerJump;
    public event EventHandler OnPlayerSecondInteract;
    public event EventHandler OnPlayerRun;
    public event EventHandler OnPlayerSave;
    public event EventHandler OnMenuExit;
    public event EventHandler OnPhoneOpen;
    public event EventHandler OnBuildingMenuOpen;
    public event EventHandler OnPlayerMainAction;
    public event EventHandler OnPlayerSecondMainAction;
    public event EventHandler OnPlayerExitInteract;



    private void Awake()
    {
        inputActions = new MainInputAction();
        inputActions.Enable();
        if (Instance != null)
        {
            Debug.LogError("There are more then one PlayerInput");
        }
        Instance = this;
    }
    private void Start()
    {
        inputActions.PLayer.PlayerInteract.performed += PlayerInteract_performed;
        inputActions.PLayer.PlayerSecondInteract.performed += PlayerSecondInteract_performed;
        inputActions.PLayer.MenuExit.performed += MenuExit_performed;
        inputActions.PLayer.PhoneOpen.performed += PhoneOpen_performed;
        inputActions.PLayer.BuildingMenu.performed += BuildingMenu_performed;
        inputActions.PLayer.SingleMainAction.performed += SingleMainAction_performed;
        inputActions.PLayer.SecondMainAction.performed += SecondMainAction_performed;
        inputActions.PLayer.ExitInteract.performed += ExitInteract_performed;
        inputActions.PLayer.PlayerJump.performed += PlayerJump_performed;
    }

    private void PlayerJump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPLayerJump?.Invoke(this, EventArgs.Empty);
    }

    private void ExitInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerExitInteract?.Invoke(this, EventArgs.Empty);
    }

    private void SecondMainAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerSecondMainAction?.Invoke(this, EventArgs.Empty);
    }

    private void SingleMainAction_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerMainAction?.Invoke(this, EventArgs.Empty);
    }

    private void BuildingMenu_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnBuildingMenuOpen?.Invoke(this, EventArgs.Empty);
    }

    private void PhoneOpen_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPhoneOpen?.Invoke(this, EventArgs.Empty);
    }

    private void MenuExit_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnMenuExit?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerSecondInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerSecondInteract?.Invoke(this, EventArgs.Empty);
    }

    private void PlayerInteract_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnPlayerInteract?.Invoke(this, EventArgs.Empty);
    }
    public bool HoldingMainAction()
    {
        return inputActions.PLayer.HoldMainAction.ReadValue<float>() > 0;
    }
    public bool PlayerRun()
    {
        return inputActions.PLayer.PlayerRun.ReadValue<float>() > 0;
    }
    public Vector2 GetInputVector()
    {
        return inputActions.PLayer.Move.ReadValue<Vector2>();
    }

    private void Update()
    {      
        if (Input.GetKey(KeyCode.F5))
        {
            OnPlayerSave?.Invoke(this, EventArgs.Empty);
        }     
    }

   
}
