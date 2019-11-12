using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IStage
{
    string SceneName
    {
        get;
    }
}

public class SceneStage : IStage
{
    public SceneStage(string sceneName)
    {
        this.SceneName = sceneName;
    }

    public string SceneName { get; }
}