using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public partial class CreateArena : MonoBehaviour
{
    [SerializeField] private RegularTile regularTile;
    [SerializeField] private SpikesTile spikesTile;
    [SerializeField] private BarrierTile barrierTile;
    [SerializeField] private BarrelTile barrelTile;
    [SerializeField] private SpawnerTile spawnerTile;

    private string[] currentPattern;
    private Tile[] instantiatedTiles;
    private string[] nextPattern;
    [SerializeField] private float timeBetweenTransformations;

    [SerializeField] private float graphWidth;
    [SerializeField] private int horizontalCount;

    // Modifiers for localScale of blocks. Proportion of total possible scale.
    [SerializeField] private float tileXScaleModifier;
    [SerializeField] private float tileZScaleModifier;
    [SerializeField] private float tileYScale;
    private float Step => graphWidth / horizontalCount;
    private float TileXScale => Step * tileXScaleModifier;
    private float TileZScale => Step * tileZScaleModifier;
    private Vector3 TileScale => new Vector3(TileXScale, tileYScale, TileZScale);

    void Start()
    {
        nextPattern = GetRandomPatternData(GetPatternData.Data);
        currentPattern = InitializeCurrentPatternWithRegularTiles(nextPattern);
        instantiatedTiles = InitializeArena(currentPattern);
        StartCoroutine(StartTimerForTransformations(timeBetweenTransformations));
    }

    private string[] GetRandomPatternData(string[][] patternData)
    {
        return patternData[Random.Range(0, patternData.Length)];
    }

    private void UpdateCurrentAndNextPatterns(string[] nextPattern_, string[][] patternData)
    {
        currentPattern = nextPattern_;
        nextPattern = GetRandomPatternData(patternData);
    }

    private string[] InitializeCurrentPatternWithRegularTiles(string[] nextPattern)
    {
        string[] patternWithZeros = new string[nextPattern.Length];
        for (int i = 0; i < nextPattern.Length; i++)
        {
            patternWithZeros[i] = TileCodes.Regular;
        }

        return patternWithZeros;
    }

    private Tile[] InitializeArena(string[] currentPattern_)
    {
        int patternLength = currentPattern_.Length;
        Tile[] instantiatedTiles_ = new Tile[patternLength];

        for (int i = 0, x = 0, z = 0; i < currentPattern_.Length; i++, x++)
        {
            if (x == horizontalCount)
            {
                x = 0;
                z += 1;
            }

            Vector3 position = new Vector3(Step * x + TileXScale / 2,
                                           -tileYScale / 2, // This is negative because the arena is upside down
                                           Step * z + TileZScale / 2);

            instantiatedTiles_[i] = CreateTileOfType(currentPattern_[i], TileScale, position);
        }
        
        return instantiatedTiles_;
    }

    private Tile CreateTileOfType(string type, Vector3 scale, Vector3 position)
    {
        switch (type)
        {
            case TileCodes.Spikes:
                return InstantiateTile(spikesTile, transform, scale, position) as SpikesTile;
            case TileCodes.Barrier:
                return InstantiateTile(barrierTile, transform, scale, position) as BarrierTile;
            case TileCodes.Barrel:
                return InstantiateTile(barrelTile, transform, scale, position) as BarrelTile;
            case TileCodes.Spawner:
                return InstantiateTile(spawnerTile, transform, scale, position) as SpawnerTile;
            default:
                return InstantiateTile(regularTile, transform, scale, position) as RegularTile;
        }
    }

    private Tile InstantiateTile(Tile tilePrefab, Transform parent, Vector3 scale_, Vector3 position_)
    {
        Tile tile = Instantiate(tilePrefab, parent, false);
        tile.transform.localScale = scale_;
        tile.transform.localPosition = position_;

        return tile;
    }

    private void TransformOnePatternIntoAnother(string[] currentPattern_, Tile[] instantiatedPattern_, string[] nextPattern_)
    {
        for (int i = 0; i < currentPattern.Length; i++)
        {
            if (nextPattern_[i] == currentPattern_[i]) {
                // If tile is exactly the same in nextPattern and in currentPattern, don't do anything
                continue;
            }
            else
            {
                // If space is not occupied by same type of tile, destroy current tile and instantiate new one
                instantiatedPattern_[i].DestroyTile();
                Vector3 position = instantiatedPattern_[i].transform.localPosition;
                Tile newTile = CreateTileOfType(nextPattern_[i], TileScale * 0.5f, position);
                newTile.BuildTile(TileScale, 0);
                instantiatedPattern_[i] = newTile;
            }
        }
    }

    private IEnumerator StartTimerForTransformations(float timeBetweenTransformations_)
    {
        TransformOnePatternIntoAnother(currentPattern, instantiatedTiles, nextPattern);
        UpdateCurrentAndNextPatterns(nextPattern, GetPatternData.Data);

        while (true)
        {
            yield return new WaitForSeconds(timeBetweenTransformations_);
            TransformOnePatternIntoAnother(currentPattern, instantiatedTiles, nextPattern);
            UpdateCurrentAndNextPatterns(nextPattern, GetPatternData.Data);
        }
    }
}
