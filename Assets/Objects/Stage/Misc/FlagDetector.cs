using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDetector : MonoBehaviour {
    public string scene = "ClearScene";

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameDirector.Get().Clear(scene);
    }
}
