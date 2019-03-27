using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralBehaviour : MonoBehaviour
{
    [HideInInspector]
    public static ProceduralBehaviour instance;
    public float perlinSeed;

    [Header("World Gen Settings")]
    public int worldSize;
    public float maxWorldHeight;
    public Terrain t;
    public List<HeightPass> passes = new List<HeightPass>();

    private int seed;
    private ProceduralTerrain pt;


    void Awake()
    {
        if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        seed = Random.Range(0, int.MaxValue);
        perlinSeed = Random.Range(0.0f, 1000000f);
        pt = new ProceduralTerrain(worldSize, worldSize, passes);
        t.terrainData.heightmapResolution = worldSize;
        t.terrainData.size = new Vector3(worldSize * 2.56f, maxWorldHeight, worldSize * 2.56f);
        Generate();
    }

    public void Generate()
    {
        SetSeed(seed);
        pt.Generate();
        t.terrainData.SetHeights(0, 0, pt.GetNormalizedHeights());
    }

    public void SetSeed(int s)
    {
        Random.InitState(s);
        if (seed != s)
        {
            seed = s;
        }
        perlinSeed = Random.Range(0.0f, 1000000f);
    }

}