using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    public float nextSceneThreshold = 4.0f;
    public float moveSpeed = 0.01f;

    private bool _signalled = false;
    private bool _locked = false;

    private int audio_stage = 0;
    private AudioSource audio1;
    private AudioSource audio2;

    public void SetAudioStage(int x)
    {
        audio_stage = x;
    }
    public void LockCamera()
    {
        _locked = true;
    }
    public void UnlockCamera()
    {
        _locked = false;
    }

    void Start()
    {
        audio1 = GameObject.FindGameObjectWithTag("Audio1").GetComponent<AudioSource>();
        audio2 = GameObject.FindGameObjectWithTag("Audio2").GetComponent<AudioSource>();
        audio1.Play();
    }

	void Update () {
        if (audio_stage == 0)
        {
            audio1.volume = Mathf.Min(1.0f, audio1.volume + Time.deltaTime / 20.0f);
            audio2.volume = Mathf.Max(0.0f, audio2.volume - Time.deltaTime / 1.0f);
        }
        else if (audio_stage == 1)
        {
            audio1.volume = Mathf.Max(0.0f, audio1.volume - Time.deltaTime / 1.0f);
            audio2.volume = Mathf.Min(1.0f, audio2.volume + Time.deltaTime / 1.0f);
        }
        else
        {
            audio1.volume = Mathf.Max(0.0f, audio1.volume - Time.deltaTime / 2.0f);
            audio2.volume = Mathf.Max(0.0f, audio2.volume - Time.deltaTime / 2.0f);
        }


        if (transform.position.z < nextSceneThreshold )
        {
            if (Input.GetKey(KeyCode.UpArrow) && !_locked)
            {
                Vector3 pos = transform.position;
                pos.z += moveSpeed;
                transform.position = pos;
            }
        }
        else if (!_signalled)
        {
            audio_stage = 1;

            blackScreen bs = FindObjectOfType<blackScreen>();
            bs.SetFade(2);
            audio2.Play();

            branchControl bc = FindObjectOfType<branchControl>();
            
            if ( bc.Get("A") )
            {
                GameObject[] goA = GameObject.FindGameObjectsWithTag("EnemyTextA");
                foreach (GameObject go in goA)
                {
                    scriptObject so = go.GetComponent<scriptObject>();
                    so.StartText();
                }
            }
            else
            {
                GameObject[] goB = GameObject.FindGameObjectsWithTag("EnemyTextB");
                foreach ( GameObject go in goB )
                {
                    scriptObject so = go.GetComponent<scriptObject>();
                    so.StartText();
                }
            }

            _signalled = true;
        }
        

    }
}
