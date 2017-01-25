using UnityEngine;
using System.Collections;

public class scriptTrigger : MonoBehaviour {

    public scriptObject ScriptObject;
    private bool _triggered;

    void OnTriggerEnter(Collider collid)
    {
        Debug.Log("Triggered Script");
        if (!_triggered)
        {
            ScriptObject.StartText();
            _triggered = true;
        }
    }
    void Start()
    {
        _triggered = false;
    }

}
