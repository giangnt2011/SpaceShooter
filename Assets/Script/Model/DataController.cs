using System.Collections;
using System.Collections.Generic;
using DesignPattern;
using Model.VO;
using UnityEngine;

public class DataController : Singleton<DataController>
{
    public PlayerVO playerVO;
    public EnemyVO enemyVO;
    public StageVO stageVO;
    public TilemapLoad tilemapLoad;

    public DataController()
    {
        playerVO = new PlayerVO();
        enemyVO = new EnemyVO();
        stageVO = new StageVO();
        tilemapLoad = new TilemapLoad();
    }
}
