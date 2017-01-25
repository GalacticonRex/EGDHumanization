﻿using UnityEngine;
using System.Collections;

public class choiceTrigger : MonoBehaviour {

    public choiceObject ChoiceObject;
    private bool _triggered;

    void OnTriggerEnter(Collider collid)
    {
        if (!_triggered)
        {
            ChoiceObject.StartChoice();
            _triggered = true;
        }
    }
    void Start()
    {
        _triggered = false;
    }

}
