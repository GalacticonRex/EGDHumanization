using UnityEngine;
using System.Collections;

public class cameraControl : MonoBehaviour {
    public float nextSceneThreshold = 4.0f;
    public float moveSpeed = 0.01f;
    private bool _signalled = false;

	void Update () {
        if (transform.position.z < nextSceneThreshold )
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 pos = transform.position;
                pos.z += moveSpeed;
                transform.position = pos;
            }
        }
        else if (!_signalled)
        {
            blackScreen bs = FindObjectOfType<blackScreen>();
            bs.FadeIn();

            GameObject go = GameObject.FindGameObjectWithTag("EnemyText");
            scriptObject so = go.GetComponent<scriptObject>();
            so.StartText();

            _signalled = true;
        }
        

    }
}
