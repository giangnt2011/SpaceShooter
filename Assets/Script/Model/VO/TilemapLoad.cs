using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapLoad
{ public GameObject LoadTilemap(int level)
    {
        GameObject loadedTilemap = Resources.Load<GameObject>("Tilemap/lv" + level);
        return loadedTilemap;
    }
}
