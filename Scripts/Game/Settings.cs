using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settings : MonoBehaviour
{
    public static Settings Instance { get; private set; }
    [SerializeField] private GameObject menu;

    [Header("Screen")]
    [SerializeField] private TMP_Dropdown dropDownResolution;
    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;
    private float currentRefreshRate;
    private int currentResolutionIndex = 0;
    


    private void Awake()
    {
        if(Instance != null)
        {
            Debug.Log("more than one settings");
        }
        Instance = this;
    }
    private void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        dropDownResolution.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;
        for(int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + " x " + filteredResolutions[i].height + " ";// + filteredResolutions[i].refreshRate + "Hz"; 
            options.Add(resolutionOption);

            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropDownResolution.AddOptions(options);
        dropDownResolution.value = currentResolutionIndex;
        dropDownResolution.RefreshShownValue();

        PlayerInputs.Instance.OnMenuExit += PlayerInputs_OnMenuExit;
    }

    private void PlayerInputs_OnMenuExit(object sender, System.EventArgs e)
    {
        Exit();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
        menu.SetActive(true);
    }
    
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
}
