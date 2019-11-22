using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlText : MonoBehaviour
{
    public TextMesh text;
    public string[] keyboard;
    public string[] joystick;
    string texttemplate;

    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
            text = GetComponent<TextMesh>();

        texttemplate = text.text;
    }

    private void Update()
    {
        var args = (Input.GetJoystickNames().Length > 0) ? joystick : keyboard;
        text.text = string.Format(texttemplate, args);
    }
}
