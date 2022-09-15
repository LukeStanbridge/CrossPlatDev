using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class FloatEditor : MonoBehaviour
{
    [Header("Components")]
    public Slider slider;
    public TMP_InputField input;
    // string used to format the text field when you move the slider
    public string formatString = "0.0";


    // property for our float value that sets any slider or input we may have attached
    float _floatValue;
    public float floatValue
    {
        get { return _floatValue; }
        set
        {
            // update our internal variable
            _floatValue = value;
            // make sure all our controls are visually consistent
            if (slider)
                slider.value = value;
            if (input)
                input.text = value.ToString(formatString);

            // update any client code that has registered with our event
            onValueChanged.Invoke(_floatValue);
        }
    }

    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }
    public FloatEvent onValueChanged;

    void Start()
    {
        if (slider)
            slider.onValueChanged.AddListener((float value) => {
                floatValue = value;
            });
        if (input)
            input.onEndEdit.AddListener((string text) =>
            {
                float parsedValue;
                if (float.TryParse(text, out parsedValue))
                    floatValue = parsedValue;
            });
    }
}
