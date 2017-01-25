using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class blackScreen : MonoBehaviour {

    public float fadeTime = 1.0f;

    private UnityEngine.UI.MaskableGraphic _image;
    private List<UnityEngine.UI.MaskableGraphic> _children;
    private int _triggered;
    private bool _children_showing;
    private float _alpha;
    private float _alpha_showing;
    private bool _running;

    public void SetFade( int x )
    {
        _triggered = System.Math.Max(System.Math.Min(x, 2), 0);
    }
    public void SetFadeToZero()
    {
        _triggered = 0;
    }
    public void SetFadeToOne()
    {
        _triggered = 1;
    }
    public void SetFadeToTwo()
    {
        _triggered = 2;
    }
    void Start()
    {
        _image = GetComponent<UnityEngine.UI.MaskableGraphic>();
        _image.color = new Color(0, 0, 0, 0);
        _children_showing = false;
        _triggered = 0;
        _alpha = 1.5f;
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
        if (_triggered == 2)
        {
            if (_alpha == 1.0f)
            {
                foreach (UnityEngine.UI.MaskableGraphic img in _children)
                    img.color = new Color(1, 1, 1, _alpha_showing);
                _alpha_showing = Mathf.Min(_alpha_showing + Time.deltaTime / fadeTime, 1.0f);
            }
            else
                _alpha = Mathf.Min(_alpha + Time.deltaTime / fadeTime, 1.0f);
        }
        else if (_triggered == 1)
        {
            if (_alpha_showing > 0.0f)
            {
                foreach (UnityEngine.UI.MaskableGraphic img in _children)
                    img.color = new Color(1, 1, 1, _alpha_showing);
                _alpha_showing = Mathf.Max(_alpha_showing - Time.deltaTime / fadeTime, 0.0f);
            }
            else
                _alpha = Mathf.Min(_alpha + Time.deltaTime / fadeTime, 1.0f);
        }
        else
        {
            if (_alpha_showing > 0.0f)
            {
                foreach (UnityEngine.UI.MaskableGraphic img in _children)
                    img.color = new Color(1, 1, 1, _alpha_showing);
                _alpha_showing = Mathf.Max(_alpha_showing - Time.deltaTime / fadeTime, 0.0f);
            }
            else
                _alpha = Mathf.Max(_alpha - Time.deltaTime / fadeTime, 0.0f);
        }

        _image.color = new Color(0, 0, 0, _alpha);
    }
}
