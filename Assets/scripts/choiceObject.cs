using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class choiceObject : MonoBehaviour {

    public int FadeLevel = 0;
    public string[] PrereqNames;
    public bool[] PrereqValues;
    public string FirstChoice;
    public string SecondChoice;
    public scriptObject AfterChoice1;
    public scriptObject AfterChoice2;

    private cameraControl _main_camera;
    private branchControl _control;
    
    public void StartChoice()
    {
        _main_camera.LockCamera();
        _control.ShowChoices(this);
    }
    public void DoneChoice()
    {
        _main_camera.UnlockCamera();
        FindObjectOfType<blackScreen>().SetFade(FadeLevel);
    }

    void Start()
    {
        _main_camera = FindObjectOfType<cameraControl>();
        _control = FindObjectOfType<branchControl>();
    }

}