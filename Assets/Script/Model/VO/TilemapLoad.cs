using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TilemapLoad
{
    public Tilemap tilemap;
    private void LoadTilemap(string name)
    {
        Tilemap loadedTilemap = Resources.Load<Tilemap>("Tilemaps/" + name);
        if (loadedTilemap != null)
        {
            tilemap.SetTiles(loadedTilemap.cellBounds.allPositionsWithin, loadedTilemap.GetTilesBlock(loadedTilemap.cellBounds));
        }
    }
}
