using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagDetector : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameDirector").GetComponent<GameDirector>().Clear();
    }
}
