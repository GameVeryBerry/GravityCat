using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {
    public GameObject scoreboard;
    public PlayerController player;

    Text scoreboardText;
    float time = 0;

	// Use this for initialization
	void Start () {
        scoreboardText = scoreboard.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        scoreboardText.text = "タイム: " + time.ToString("F2") + "秒";
	}

    public void Clear()
    {
        PlayerPrefs.SetFloat("saveddata.time", time);
        SceneManager.LoadScene("ClearScene");
    }

    public static GameDirector Get()
    {
        return GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }
}
