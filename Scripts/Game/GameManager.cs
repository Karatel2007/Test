using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject phone, phoneHead, phoneWorks;
    
    
     private bool phoneIsOpen;
    
    private void Start()
    {
        phoneIsOpen = false;
        phone.SetActive(false); 
        phoneHead.SetActive(false);
        phoneWorks.SetActive(false);


        PlayerInputs.Instance.OnPhoneOpen += PlayerInputs_OnPhoneOpen;
        PlayerInputs.Instance.OnMenuExit += PlayerInputs_OnMenuExit;
    }

    private void PlayerInputs_OnMenuExit(object sender, System.EventArgs e)
    {
        if(phoneIsOpen)
        {
            ClosePhone();
        }

    }

    private void PlayerInputs_OnPhoneOpen(object sender, System.EventArgs e)
    {
        if (phoneIsOpen == false)
        {
            OpenPhone();
        }
        else 
        {
            ClosePhone();
        }
    }
    public void WorkButton ()
    {
        phoneWorks.SetActive(true);   
        phoneHead.SetActive(false);
    }

    public void BackToHeadButton ()
    {
        phoneWorks.SetActive(false);   
        phoneHead.SetActive(true);
    }
    
    private void OpenPhone()
    {
        phone.SetActive(true);
        phoneHead.SetActive(true);
        phoneIsOpen = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
    private void ClosePhone()
    {
        phone.SetActive(false);
        phoneIsOpen = false;
        Cursor.lockState = CursorLockMode.Locked;
        phoneWorks.SetActive(false);
    }

}
