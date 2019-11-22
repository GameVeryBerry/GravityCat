using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleDirector : MonoBehaviour {
    public Stage stage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool jumpButton = Input.GetButtonDown("Submit");
        if (jumpButton)
            SceneManager.LoadScene(stage.sceneName);
    }
}
