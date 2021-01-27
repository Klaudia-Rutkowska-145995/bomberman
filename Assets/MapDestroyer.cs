using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer : MonoBehaviour
{
    public Tilemap tilemap;

    public Tile wallTile;
    public Tile destructableTile;

    public GameObject explosionPrefab;

    public GameObject player;
    public GameObject[] enemies;

    private GameObject instantiatedObj;

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);

        ExplodeCell(originCell);

        if (ExplodeCell(originCell + new Vector3Int(1, 0, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(2, 0, 0));
        }

        if (ExplodeCell(originCell + new Vector3Int(0, 1, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(0, 2, 0));
        }

        if (ExplodeCell(originCell + new Vector3Int(-1, 0, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(-2, 0, 0));
        }

        if (ExplodeCell(originCell + new Vector3Int(0, -1, 0)))
        {
            ExplodeCell(originCell + new Vector3Int(0, -2, 0));
        }
    }

    bool ExplodeCell(Vector3Int cell)
    {
        CheckPlayerToKill(cell);
        CheckEnemyToKill(cell);

        Tile tile = tilemap.GetTile<Tile>(cell);

        if (tile == wallTile)
        {
            return false;
        }

        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        instantiatedObj = (GameObject)Instantiate(explosionPrefab, pos, Quaternion.identity);

        Destroy(instantiatedObj, 1f);

        if (tile == destructableTile)
        {
            tilemap.SetTile(cell, null);

            return false;
        }

        return true;
    }

    private void CheckPlayerToKill(Vector3Int cell)
    {
        var playerPos = new Vector3Int(
            Mathf.FloorToInt(player.transform.position.x),
            Mathf.FloorToInt(player.transform.position.y),
            0
        );

        if (playerPos == cell)
        {
            player.GetComponent<PlayerKiller>().killPlayer();
        }
    }

    private void CheckEnemyToKill(Vector3Int cell)
    {
        for (var i = 0; i < enemies.Length; i++)
        {
            var enemyPos = new Vector3Int(
                Mathf.FloorToInt(enemies[i].transform.position.x),
                Mathf.FloorToInt(enemies[i].transform.position.y),
                0
            );

            if (enemyPos == cell)
            {
                enemies[i].GetComponent<EnemyKiller>().killEnemy();
            }
        }
    }
}
