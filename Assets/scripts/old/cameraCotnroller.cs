using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class cameraCotnroller : MonoBehaviour {

    public float defaultSize = 1.0f;
    private Stack<hiddenEnvironment> environments;
    private Camera mainCamera;

    public void Push(hiddenEnvironment env)
    {
        environments.Push(env);
    }
    public void Pop()
    {
        environments.Pop();
    }

    void Start()
    {
        environments = new Stack<hiddenEnvironment>();
        mainCamera = GetComponent<Camera>();
    }
	void Update ()
    {
        float target = (environments.Count == 0) ? defaultSize : environments.Peek().CameraSize;

        float dif = (target - mainCamera.orthographicSize);
        float delta = Mathf.Sign(dif) * 0.05f + dif / 12.0f;
        mainCamera.orthographicSize += dif / 12.0f;
    }
}
