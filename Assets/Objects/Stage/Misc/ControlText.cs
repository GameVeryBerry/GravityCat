using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class ControlText : MonoBehaviour
{
    Text text;
    TextMesh textMesh;
    public string[] keyboard;
    public string[] joystick;
    string texttemplate;

    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
            if (text != null)
                texttemplate = text.text;
        }
        if (textMesh == null)
        {
            textMesh = GetComponent<TextMesh>();
            if (textMesh != null)
                texttemplate = textMesh.text;
        }
    }

    private void Update()
    {
        var args = (Input.GetJoystickNames().Where(e => !string.IsNullOrEmpty(e)).Count() > 0) ? joystick : keyboard;
        if (text != null)
            text.text = string.Format(texttemplate, args);
        if (textMesh != null)
            textMesh.text = string.Format(texttemplate, args);
    }
}
