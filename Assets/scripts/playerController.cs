using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

    public float speed = 0.25f;

    private Rigidbody2D rigidBody;
    private Camera mainCamera;

	// Use this for initialization
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        mainCamera = FindObjectOfType<Camera>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        hiddenEnvironment obj = other.GetComponent<hiddenEnvironment>();
        if ( obj != null )
            obj.SignalEnter();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        hiddenEnvironment obj = other.GetComponent<hiddenEnvironment>();
        if (obj != null)
            obj.SignalExit();
    }

    // Update is called once per frame
    void Update ()
    {
        rigidBody.velocity = new Vector2(0, 0);

	    if ( Input.GetKey(KeyCode.LeftArrow) )
            rigidBody.velocity += new Vector2(-speed, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            rigidBody.velocity += new Vector2( speed, 0);

        mainCamera.transform.position =
            new Vector3(transform.position.x, transform.position.y, -10);
    }
}
