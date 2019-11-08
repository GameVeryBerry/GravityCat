using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClearDirector : MonoBehaviour {
    public Text scoreboard;

    float time;
    float bestTime = -1;

	// Use this for initialization
	void Start () {
        time = PlayerPrefs.GetFloat("saveddata.time", -1);
        bestTime = PlayerPrefs.GetFloat("saveddata.time.best", -1);

        if (time >= 0 && (bestTime < 0 || time < bestTime))
            PlayerPrefs.SetFloat("saveddata.time.best", bestTime = time);

        scoreboard = GameObject.Find("Scoreboard").GetComponent<Text>();
        scoreboard.text = "クリアタイム: " + time.ToString("F2") + "秒" + "\n" + "ベストタイム: " + bestTime.ToString("F2") + "秒";
    }

    // Update is called once per frame
    void Update () {
        bool jumpButton = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
        if (jumpButton)
            SceneManager.LoadScene("TitleScene");
	}
}
