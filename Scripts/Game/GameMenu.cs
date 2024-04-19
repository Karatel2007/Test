using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField] private GameObject menuVisual;

    private void Start()
    {
        PlayerInputs.Instance.OnMenuExit += PlayerInputs_OnMenuExit;
    }

    private void PlayerInputs_OnMenuExit(object sender, System.EventArgs e)
    {
        menuVisual.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 0;
    }

   
    public void CloseMenu()
    {
        menuVisual.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

   
    public void LoadStartMenu(int level)
    {
        SceneManager.LoadScene(level);
    }
    
    
}
