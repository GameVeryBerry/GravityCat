using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    Text scoreboard;
    float time = 0;

	// Use this for initialization
	void Start () {
        scoreboard = GameObject.Find("Scoreboard").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        scoreboard.text = "タイム: " + time.ToString("F2") + "秒";
	}

    public void Clear()
    {
        PlayerPrefs.SetFloat("saveddata.time", time);
        SceneManager.LoadScene("ClearScene");
    }
}
