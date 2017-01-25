using UnityEngine;
using System.Collections;

public class hiddenEnvironment : MonoBehaviour {

    public float CameraSize = 1.0f;
    private SpriteRenderer foreground;
    private cameraCotnroller camCtrl;
    private float alpha = 1.0f;
    private bool triggered = false;
    
    public void SignalEnter()
    {
        triggered = true;
        camCtrl.Push(this);
    }
    public void SignalExit()
    {
        triggered = false;
        camCtrl.Pop();
    }

    void Start()
    {
        foreground = GetComponent<SpriteRenderer>();
        camCtrl = FindObjectOfType<cameraCotnroller>();
    }
    void Update()
    {
        alpha = (triggered) ? 
                Mathf.Max(0.0f, alpha - 0.05f) : 
                Mathf.Min(1.0f, alpha + 0.05f);
        foreground.color = new Color(1.0f, 1.0f, 1.0f, alpha);
    }
}
