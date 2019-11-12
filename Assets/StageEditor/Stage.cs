using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
  fileName = "Stage",
  menuName = "ステージ作成/ステージマニフェスト",
  order = 100)
]
[Serializable]
public class Stage : ScriptableObject, IStage
{
    public string stageName;
    public Stage nextStage;
    public string sceneName;
    public Stage[] rewardStages;
    public Texture thumbnail;
    [TextArea(10, 30)]
    public string description;
    public int bgmId = -1;

    public string SceneName
    {
        get
        {
            return sceneName;
        }
    }
}
