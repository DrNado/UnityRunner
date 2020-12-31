using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscriptControlaTiles : MonoBehaviour
{
    public GameObject[] TilePrefabs;
    private Transform TransformaPlayer;
    private float SpawnDosTileNoZ = -6.0f;
    private float LarguraDosTiles = 12.0f;
    private int NumeroDeTilesNaTela = 7;
    private float StartZone = 15.0f;
    private int PegaONumDosPrefab = 0;

    private List<GameObject> TilesAtivos;

    private void TileSpowner(int Nprefabs = -1)
    {
        GameObject go;
        if (Nprefabs == -1)
        {
            go = Instantiate(TilePrefabs[RandomPrefabs()]) as GameObject;
        }
        else
        {
            go = Instantiate(TilePrefabs[Nprefabs]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnDosTileNoZ;
        SpawnDosTileNoZ += LarguraDosTiles;
        TilesAtivos.Add(go);
      
       
    }

    // Start is called before the first frame update
    void Start()
    {
        TilesAtivos = new List<GameObject>();
        TransformaPlayer = GameObject.FindGameObjectWithTag("Player").transform;
        for (int i = 0; i < NumeroDeTilesNaTela; i++)
        {
            if (i<2)
            {
                TileSpowner(0);
            }
            else
            {
                TileSpowner();
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (TransformaPlayer.position.z - StartZone >(SpawnDosTileNoZ - NumeroDeTilesNaTela * LarguraDosTiles))
        {
            TileSpowner();
            DeleteTile();
        }
    }

    private void DeleteTile()
    {
        Destroy(TilesAtivos[0]);
        TilesAtivos.RemoveAt(0);
    }

    private int RandomPrefabs()
    {
        if (TilePrefabs.Length <= 1)
        {
            return 0;
        }
        int RandomTiles = PegaONumDosPrefab;
        while (RandomTiles == PegaONumDosPrefab)
        {
            RandomTiles = Random.Range(0, TilePrefabs.Length);
        }
        PegaONumDosPrefab = RandomTiles;
        return RandomTiles;
    }
}
