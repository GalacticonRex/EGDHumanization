using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blackScreen : MonoBehaviour {

    public float fadeTime = 1.0f;

    private UnityEngine.UI.MaskableGraphic _image;
    private List<UnityEngine.UI.MaskableGraphic> _children;
    private bool _triggered;
    private bool _children_showing;
    private float _alpha;
    private float _alpha_showing;

	public void FadeIn()
    {
        _triggered = true;
    }
    public void FadeOut()
    {
        _triggered = false;
    }
    void Start()
    {
        _image = GetComponent<UnityEngine.UI.MaskableGraphic>();
        _image.color = new Color(0, 0, 0, 0);
        _children_showing = false;
        _triggered = false;
        _alpha = 0.0f;
        _alpha_showing = 0.0f;
        _children = new List<UnityEngine.UI.MaskableGraphic>();
        Debug.Log(transform.childCount);
        for (int i=0;i<transform.childCount;i++ )
        {
            Transform t = transform.GetChild(i);
            UnityEngine.UI.MaskableGraphic img = t.GetComponent<UnityEngine.UI.MaskableGraphic>();
            if ( img != null )
            {
                _children.Add(img);
                img.color = new Color(1, 1, 1, 0);
            }
        }
    }
	void Update()
    {
        if (_triggered)
        {
            if (_alpha == 1.0f)
            {
                foreach ( UnityEngine.UI.MaskableGraphic img in _children )
                    img.color = new Color(1, 1, 1, _alpha_showing);
                _alpha_showing = Mathf.Min(_alpha_showing + Time.deltaTime / fadeTime, 1.0f);
            }
            else
                _alpha = Mathf.Min(_alpha + Time.deltaTime / fadeTime, 1.0f);
        }
        else
        {
            if (_alpha_showing > 0.0f)
            {
                foreach (UnityEngine.UI.Image img in _children)
                    img.color = new Color(1, 1, 1, _alpha_showing);
                _alpha_showing = Mathf.Max(_alpha_showing - Time.deltaTime / fadeTime, 0.0f);
            }
            else
                _alpha = Mathf.Max(_alpha - Time.deltaTime / fadeTime, 0.0f);
        }

        _image.color = new Color(0, 0, 0, _alpha);
    }
}
