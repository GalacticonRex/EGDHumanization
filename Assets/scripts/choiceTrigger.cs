using UnityEngine;
using System.Collections;

public class choiceTrigger : MonoBehaviour {

    public choiceObject Object;
    private branchControl _control;
    private bool _triggerd;

    void OnTriggerEnter(Collider collid)
    {
        if (!_triggerd)
        {
            _control.ShowChoices(Object);
            _triggerd = true;
        }
    }
    void Start()
    {
        _control = FindObjectOfType<branchControl>();
        _triggerd = false;
    }

}
