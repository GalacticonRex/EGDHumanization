using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class branchControl : MonoBehaviour {

    private List<UnityEngine.UI.Button> _objects;
    private Dictionary<string, bool> _choices;
    private choiceObject _current_choice;

    public void SelectFirstChoice()
    {
        _choices[_current_choice.name] = true;
        HideChoices();
    }
    public void SelectSecondChoice()
    {
        _choices[_current_choice.name] = false;
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
