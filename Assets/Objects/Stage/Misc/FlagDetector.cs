using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDetector : MonoBehaviour
{
    public Stage stage;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (stage != null)
            GameDirector.Get().Clear(stage.sceneName);
    }
}
