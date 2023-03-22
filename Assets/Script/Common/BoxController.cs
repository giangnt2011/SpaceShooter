using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BoxController : MonoBehaviour
{
    private Tilemap tilemap;
    private void Start()
    {
        Debug.Log("tiel");
        tilemap = GetComponent<Tilemap>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag(GameKey.TAG_BULLET))
        {
            Debug.Log("bullet");
            var tilePos = tilemap.WorldToCell(collision.gameObject.transform.position);
            tilemap.SetTile(tilePos, null);
            tilemap.SetTile(new Vector3Int(tilePos.x, tilePos.y + 1 , tilePos.z), null);
            Creator.Instance.CreateExplosion(collision.gameObject.transform);
            Destroy(collision.gameObject);
        }
    }
}
