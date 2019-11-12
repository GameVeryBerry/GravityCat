using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool jumpButton = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        if (jumpButton)
            SceneManager.LoadScene("GameScene");
    }
}
