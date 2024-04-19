using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GraphicsSettings : MonoBehaviour
{
    private void Start()
    {
       
    }

    public void TurnOnPostProcesing()
    {
        Camera.main.GetUniversalAdditionalCameraData().renderPostProcessing = true;
    }
    public void TurnOffPostProcesing()
    {
        Camera.main.GetUniversalAdditionalCameraData().renderPostProcessing = false;
    }
    public void TurnOnShadows()
    {
        Camera.main.GetUniversalAdditionalCameraData().renderShadows = true;
    }
    public void TurnOffShadows()
    {
        Camera.main.GetUniversalAdditionalCameraData().renderShadows = false;
    }

}
