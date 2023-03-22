using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridforTilemapController : MonoBehaviour
{
    public Tilemap tilemap;

    void Start()
    {
        Tilemap loadedTilemap = Resources.Load<Tilemap>("Tilemaps/" + tilemap.name);
        if (loadedTilemap != null)
        {
        }
    }
}
