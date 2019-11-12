using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaDetector : MonoBehaviour {
    PlayerController player;
    Collider2D collider2d;

	// Use this for initialization
	void Start () {
        player = GameDirector.Get().player;
        collider2d = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!collider2d.OverlapPoint(player.transform.position))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
