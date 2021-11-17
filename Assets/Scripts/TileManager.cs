using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] TilePrefabs;

    private Transform PlayerTransform;
    private float spawnZ = 0.0f;
    private float SafeZone = 138.5f;//used to keep the first bridges from beeing deleted
    private float TileLength = 138.2f;//length of the bridge on screen in meter
    private int NumberOfTilesOnScreen = 2;//number of bridges on screen
    private int lastPrefabIndex = 0;//used to avoid creating the same bridge twice

    private List<GameObject> ActiveTiles;//to keep track of the built bridges so we can delete them

    // Start is called before the first frame update
    void Start()
    {
        ActiveTiles = new List<GameObject>();
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;//spawn according to the place of the player

        //makes 7 bridges at the begginig 
        for (int i = 0; i < NumberOfTilesOnScreen; i++)
        {
            if (i < 1)
                SpawnTile(0);
            else
                SpawnTile();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //every time we pass a bridge, this appends a new one at the end of the road
        if (PlayerTransform.position.z - SafeZone > (spawnZ - NumberOfTilesOnScreen * TileLength))
        {
            SpawnTile();
            DeleteTile();
        }
    }

    //to create new bridges
    private void SpawnTile(int prefabIndex = -1)
    {
        GameObject GO;
        if (prefabIndex == -1)
            GO = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            GO = Instantiate(TilePrefabs[prefabIndex]) as GameObject;

        GO.transform.SetParent(transform);// every new bridge, will go under Tile Manager(for tidiness of our work)
        GO.transform.position = Vector3.forward * spawnZ;
        spawnZ += TileLength;
        ActiveTiles.Add(GO);
    }

    //to delete the passed bridges to avoid memoryOverFlow
    private void DeleteTile()
    {
        Destroy(ActiveTiles[0]);
        ActiveTiles.RemoveAt(0);
    }

    //avoid creating the same bridge twice
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0;

        int RandomIndex = lastPrefabIndex;
        while (RandomIndex == lastPrefabIndex)
        {
            RandomIndex = Random.Range(0, TilePrefabs.Length);
        }

        lastPrefabIndex = RandomIndex;
        return RandomIndex;

    }
}
