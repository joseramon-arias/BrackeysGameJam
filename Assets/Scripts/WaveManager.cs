using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}

public enum EnemyName
{
    Gunner,
    Kamikaze,
    Ninja
}

public class WaveManager : MonoBehaviour
{
    // Patterns of different difficulty
    [SerializeField] private TextAsset patternsEasy;
    [SerializeField] private TextAsset patternsMedium;
    [SerializeField] private TextAsset patternsHard;
    [SerializeField] private GetPatternData getPatternData;

    // All different enemies
    [SerializeField] private Enemy gunner;
    [SerializeField] private Enemy kamikaze;
    [SerializeField] private Enemy ninja;
    private EnemyName[] enemiesNames;
    private Enemy[] enemies;

    // Stack from which to get enemies for current wave
    private List<Enemy> enemiesForCurrentWave;

    private Difficulty currentDifficulty;
    private int MaxNumberOfDifficultyLevels => Enum.GetNames(typeof(Difficulty)).Length;
    private int waveCount;
    private WaveParameters currentWaveParameters;
    public WaveParameters CurrentWaveParameters => currentWaveParameters;
    [SerializeField] private TMPro.TextMeshProUGUI waveNumberText;
    // How many waves are in each difficulty
    [SerializeField] private int maxWavesPerDifficulty;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        // enemiesNames and enemies must be filled in the exact same order
        enemiesNames = new EnemyName[] { EnemyName.Gunner, EnemyName.Kamikaze, EnemyName.Ninja };
        enemies = new Enemy[] { gunner, kamikaze, ninja };
    }

    private void Start()
    {
        currentDifficulty = Difficulty.Easy;
        waveCount = 0;
        UpdateDifficultyParameters();
        StartNewWave();
    }

    private void Update()
    {
        if (enemiesForCurrentWave.Count == 0)
        {
            Debug.Log("Mishi");
            StartNewWave();
        }
    }

    private void UpdateDifficultyParameters()
    {
        getPatternData.PatternsCsv = GetNewPatternDifficulty(currentDifficulty);
        getPatternData.WrangleDataAndCreatePatternsArray();
        currentWaveParameters = GetWaveParameters(currentDifficulty);
    }

    private void StartNewWave()
    {
        if (waveCount != 0 && waveCount % maxWavesPerDifficulty == 0)
        {
            // We have reached maxWavePerDifficulty => change difficulty or end game
            if ((int)currentDifficulty == MaxNumberOfDifficultyLevels)
            {
                // End Game
            }
            else
            {
                // Increment difficulty and restart waveCount
                currentDifficulty = (Difficulty)(int)currentDifficulty + 1;
                waveCount = 1;
                // Read new patterns csv and build patterns data
                UpdateDifficultyParameters();
                FillEnemiesForCurrentWave();
            }
        }
        else
        {
            // We stay in current difficulty
            waveCount += 1;
            FillEnemiesForCurrentWave();
        }

        waveNumberText.text = $"Wave: {maxWavesPerDifficulty * ((int)currentDifficulty - 1) + waveCount}";
    }

    private TextAsset GetNewPatternDifficulty(Difficulty newDifficulty)
    {
        switch (newDifficulty)
        {
            case Difficulty.Easy:
                return patternsEasy;
            case Difficulty.Medium:
                return patternsMedium;
            case Difficulty.Hard:
                return patternsHard;
            default:
                return null;
        }
    }

    private Enemy GetEnemyPrefab(EnemyName enemyName)
    {
        switch (enemyName)
        {
            case EnemyName.Gunner:
                return gunner;
            case EnemyName.Kamikaze:
                return kamikaze;
            case EnemyName.Ninja:
                return ninja;
            default:
                return null;
        }
    }

    private WaveParameters GetWaveParameters(Difficulty currentDifficulty_)
    {
        switch (currentDifficulty_)
        {
            case Difficulty.Easy:
                return new EasyWaveParameters();
            case Difficulty.Medium:
                return new MediumWaveParameters();
            case Difficulty.Hard:
                return new HardWaveParameters();
            default:
                return null;
        }
    }

    private void FillEnemiesForCurrentWave()
    {
        enemiesForCurrentWave = new List<Enemy>();
        int numberOfEnemiesForThisWave = UnityEngine.Random.Range(currentWaveParameters.MinNumberOfEnemies,
                                                                  currentWaveParameters.MaxNumberOfEnemies);
        for (int i = 0; i < numberOfEnemiesForThisWave; i++)
        {
            Enemy newEnemy = enemies[Array.IndexOf(enemiesNames, currentWaveParameters.GetEnemy())];
            enemiesForCurrentWave.Add(newEnemy);
        }
    }

    public Enemy GetNextEnemyInStack()
    {
        if (enemiesForCurrentWave.Count == 0)
        {
            return null;
        }
        else
        {
            Enemy newEnemy = enemiesForCurrentWave[enemiesForCurrentWave.Count - 1];
            enemiesForCurrentWave.RemoveAt(enemiesForCurrentWave.Count - 1);
            return newEnemy;
        }
    }
}
