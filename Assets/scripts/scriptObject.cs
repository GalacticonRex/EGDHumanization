using UnityEngine;
using System.Collections;

public class scriptObject : MonoBehaviour {

    public string[] text;
    public float waitTime;
    public UnityEngine.UI.Text textBox;
    private int _next_index;
    private int _current;

    public void StartText()
    {
        StartCoroutine(NextLine());
    }

    IEnumerator NextLine()
    {
        if (_current < text.Length)
        {
            yield return new WaitForSeconds(waitTime);
            textBox.text = "";

            _next_index = 0;
            StartCoroutine(NextCharacter());
        }
        else
        {
            yield return null;
        }
    }

    IEnumerator NextCharacter()
    {
        yield return new WaitForSeconds(0.1f);
        string temp = text[_current];
        textBox.text = temp.Substring(0, _next_index);

        do
        { _next_index++; }
        while (_next_index < temp.Length && temp[_next_index] == ' ');

        if (_next_index > temp.Length)
        {
            _current++;
            StartCoroutine(NextLine());
        }
        else
            StartCoroutine(NextCharacter());

    }

    void Start()
    {
        _current = 0;
        _next_index = 0;
    }
}
