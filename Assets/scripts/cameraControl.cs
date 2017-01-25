using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    public float nextSceneThreshold = 4.0f;
    public float moveSpeed = 0.01f;

    private bool _signalled = false;
    private bool _locked = false;

    public void LockCamera()
    {
        _locked = true;
    }
    public void UnlockCamera()
    {
        _locked = false;
    }

	void Update () {
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
            blackScreen bs = FindObjectOfType<blackScreen>();
            bs.SetFade(2);

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
