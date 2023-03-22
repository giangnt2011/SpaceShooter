using DesignPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageInfo
{
    public WaveInfo[] WaveInfos;
}
public class StageController : MonoBehaviour
{
    protected StageVO stageVO => DataController.Instance.stageVO;

    private StageInfo _stageInfo;
    private int currentStage = 0;

    private void Awake()
    {
        Observer.Instance.AddObserver(GameKey.NEXT_STAGE, LoadNextStage);
        _stageInfo = stageVO.GetStageInfo(currentStage);
        InitiateWave();
    }

    void InitiateWave()
    {
        Debug.Log("Your current Stage: " + currentStage);
        WaveController wave = Creator.Instance.CreateWave(transform.position);
        wave.waveInfos = _stageInfo.WaveInfos;
        wave.start();
    }

    void LoadNextStage(object data)
    {
        currentStage++;
        Debug.Log("Your current Stage: " + currentStage);
        WaveController wave = (WaveController)data;
        _stageInfo = stageVO.GetStageInfo(currentStage);
        wave.waveInfos = _stageInfo.WaveInfos;
        wave.currentWave = 0;
        wave.start();
    }


}
