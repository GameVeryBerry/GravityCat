using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public GameObject scoreboard;
    public PlayerController player;

    public Text scoreboardText;
    float time = 0;

    // Use this for initialization
    void Start()
    {
        if (scoreboard != null)
            scoreboardText = scoreboard.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (scoreboardText != null)
            scoreboardText.text = "タイム: " + time.ToString("F2") + "秒";
    }

    public void Clear(string scene)
    {
        PlayerPrefs.SetFloat("saveddata.time", time);
        SceneManager.LoadScene(scene);
    }

    public static GameDirector Get()
    {
        return GameObject.Find("GameDirector").GetComponent<GameDirector>();
    }
}
