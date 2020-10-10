using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public UIHealthBar _instance { get; private set; }
    public Image _mask;    
    public float _value;
    private float originalSize;

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        originalSize = _mask.rectTransform.rect.width;
    }

    public void SetValue(float value)
    {
        _mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
        _value = value;
    }
}
