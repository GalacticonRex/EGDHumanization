using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class branchControl : MonoBehaviour {

    private List<UnityEngine.UI.Button> _objects;
    private Dictionary<string, bool> _choices;
    private choiceObject _current_choice;

    public bool Get(string str)
    {
        return _choices[str];
    }

    public void SelectFirstChoice()
    {
        if (_current_choice != null)
        {
            _choices[_current_choice.name] = true;
            _current_choice.DoneChoice();
            if (_current_choice.AfterChoice1 != null)
                _current_choice.AfterChoice1.StartText();
        }
        HideChoices();
    }
    public void SelectSecondChoice()
    {
        if (_current_choice != null)
        {
            _choices[_current_choice.name] = false;
            _current_choice.DoneChoice();
            if (_current_choice.AfterChoice2 != null)
                _current_choice.AfterChoice2.StartText();
        }
        HideChoices();
    }

    public void ShowChoices(choiceObject obj)
    {
        _current_choice = obj;
        _objects[0].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = obj.FirstChoice;
        _objects[1].transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = obj.SecondChoice;
        foreach (UnityEngine.UI.Button but in _objects)
            but.transform.localScale = new Vector3(1, 1, 1);
    }
    void HideChoices()
    {
        _current_choice = null;
        foreach ( UnityEngine.UI.Button but in _objects)
            but.transform.localScale = new Vector3(0, 0, 0);
    }

	void Start()
    {
        _choices = new Dictionary<string, bool>();
        _objects = new List<UnityEngine.UI.Button>();
        for ( int i=0;i<transform.childCount;i++ )
        {
            Transform t = transform.GetChild(i);
            UnityEngine.UI.Button but = t.GetComponent<UnityEngine.UI.Button>();
            if ( but != null )
                _objects.Add(but);
        }
        HideChoices();
	}
}
