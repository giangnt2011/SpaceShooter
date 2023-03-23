using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridforTilemapController : MonoBehaviour
{
    public TilemapLoad tilemapLoad => DataController.Instance.tilemapLoad;
    public GameObject tilemap;
    public int level = 0;

    void Start()
    {
        LoadTilemapLv(level);
    }

    public void LoadTilemapLv(int level)
    {
        GameObject loadedTilemap = tilemapLoad.LoadTilemap(level);
        if (loadedTilemap != null)
        {
            tilemap = Creator.Instance.LoadTilemap(loadedTilemap);
            tilemap.SetActive(true);
        }
        else
        {
            Debug.Log("Tilemap khong ton tai");
        }
    }
}

public class TilemapLoadSingleton : SingletonMonobehaviour<GridforTilemapController>
{
    
}
