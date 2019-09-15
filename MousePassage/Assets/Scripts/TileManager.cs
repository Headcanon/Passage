using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    
    ListaTiles tiles;
    List<GameObject> activeTiles;

    Transform alvo;

    float spawnY = 0;
    float tileLeght = 18;
    float tilesOnScreen = 5;

    private void Awake()
    {
        tiles = new ListaTiles("Fase1");
        activeTiles = new List<GameObject>();
        alvo = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
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
        go = Instantiate(tiles.AleatorioSemRepetir(), transform) as GameObject;
        go.transform.position = Vector2.up * spawnY;

        spawnY += tileLeght;

        activeTiles.Add(go);
    }

    void DestroyTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
