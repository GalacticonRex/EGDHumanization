using UnityEngine;
using System.Collections;

public class scriptObject : MonoBehaviour {

    public float InitialWait;
    public string[] speaker;
    public string[] text;
    public float[] waitTime;
    public UnityEngine.UI.Text speakerBox;
    public UnityEngine.UI.Text textBox;
    public choiceObject AfterText;

    private cameraControl _main_camera;
    private int _next_index;
    private int _current;

    public void StartText()
    {
        _main_camera.LockCamera();
        StartCoroutine(BeginLine());
    }

    IEnumerator BeginLine()
    {
        yield return new WaitForSeconds(InitialWait);
        if (!Input.GetKey(KeyCode.Space))
        {
            if (speakerBox != null)
                speakerBox.text = speaker[_current];
            StartCoroutine(NextCharacter());
        }
        else
        {
            Abort();
        }
    }

    IEnumerator NextLine()
    {
        yield return new WaitForSeconds(waitTime[_current]);
        if (!Input.GetKey(KeyCode.Space))
        {
            _current++;
            textBox.text = "";
            if (speakerBox != null)
                speakerBox.text = "";
            if (_current < text.Length)
            {
                if (speakerBox != null)
                    speakerBox.text = speaker[_current];
                _next_index = 0;
                StartCoroutine(NextCharacter());
            }
            else
            {
                _main_camera.UnlockCamera();
                if (AfterText != null)
                    AfterText.StartChoice();
            }
        }
        else
        {
            Abort();
        }
    }

    IEnumerator NextCharacter()
    {
        yield return new WaitForSeconds(0.025f);
        if (!Input.GetKey(KeyCode.Space))
        {
            string temp = text[_current];
            textBox.text = temp.Substring(0, _next_index);

            do
            { _next_index++; }
            while (_next_index < temp.Length && temp[_next_index] == ' ');

            if (_next_index > temp.Length)
                StartCoroutine(NextLine());
            else
                StartCoroutine(NextCharacter());
        }
        else
        {
            Abort();
        }
    }

    void Abort()
    {
        Debug.Log("Interrupt");
        textBox.text = "";
        if (speakerBox != null)
            speakerBox.text = "";
        _main_camera.UnlockCamera();
        if (AfterText != null)
            AfterText.StartChoice();
    }

    void Start()
    {
        _main_camera = FindObjectOfType<cameraControl>();
        _current = 0;
        _next_index = 0;
    }
}
