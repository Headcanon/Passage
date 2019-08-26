using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    
    public List<GameObject> tiles;
    List<GameObject> activeTiles;

    Transform alvo;

    float spawnY = 0;
    float tileLeght = 18;
    float tilesOnScreen = 5;

    int lastPrefabIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        alvo = GameObject.FindGameObjectWithTag("Player").transform;

        lastPrefabIndex = Random.Range(0, activeTiles.Count);

        for (int i = 0; i < tilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (alvo != null)
        {
            if (alvo.position.y - tileLeght > (spawnY - tilesOnScreen * tileLeght))
            {
                SpawnTile();
                DestroyTile();
            }
        }
    }

    void SpawnTile()
    {
        GameObject go;
        go = Instantiate(tiles[RandomIndex()], transform) as GameObject;
        go.transform.position = Vector2.up * spawnY;

        spawnY += tileLeght;

        activeTiles.Add(go);
    }

    void DestroyTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    int RandomIndex()
    {
        if (tiles.Count <= 1)
            return 0;

        int newIndex = lastPrefabIndex;
        while (newIndex == lastPrefabIndex)
        {
            newIndex = Random.Range(0, tiles.Count);
        }
        lastPrefabIndex = newIndex;
        return newIndex;
    }
}
