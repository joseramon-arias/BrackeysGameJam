using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaveParameters
{
    public abstract EnemyName[] AvailableEnemies { get; }
    // The probabilities for each available enemy
    // Each number represents the top cutoff number for probabilites between 1 and 100
    // For example:
    // Let's say we have 3 enemies: Gunner, Kamikaze and Ninja.
    // We would define 3 cutoffs: [ 15, 50, 100 ]
    // This means that if we get a number between 1 and 15, we'll get a Gunner;
    // between 15 and 50, we'll get a Kamikaze; between 50 and 100, we'll get a Ninja.
    // Translated to probabilities: Gunner has a 15% chance, Kamikaze a 35% chance, and Ninka a 50% chance
    public abstract int[] ProbabilityCutoffs { get; }
    public abstract int MinNumberOfEnemies { get; }
    public abstract int MaxNumberOfEnemies { get; }
    public abstract int MinSpawnSpeed { get; }
    public abstract int MaxSpawnSpeed { get; }

    public EnemyName GetEnemy()
    {
        int randomNumber = Random.Range(1, 101);
        for (int i = 0; i < ProbabilityCutoffs.Length; i++)
        {
            if (randomNumber <= ProbabilityCutoffs[i])
            {
                return AvailableEnemies[i];
            }
        }
        
        return AvailableEnemies[0];
    }
}

public class EasyWaveParameters : WaveParameters
{
    private EnemyName[] availableEnemies = new EnemyName[] { EnemyName.Kamikaze, EnemyName.Gunner };
    public override EnemyName[] AvailableEnemies => availableEnemies;

    private int[] probabilityCuttofs = new int[] { 85, 100 };
    public override int[] ProbabilityCutoffs => probabilityCuttofs;

    private int minNumberOfEnemies = 10;
    public override int MinNumberOfEnemies => minNumberOfEnemies;

    private int maxNumberOfEnemies = 20;
    public override int MaxNumberOfEnemies => maxNumberOfEnemies;

    private int minSpawnSpeed = 5;
    public override int MinSpawnSpeed => minSpawnSpeed;

    private int maxSpawnSpeed = 15;
    public override int MaxSpawnSpeed => maxSpawnSpeed;
}

public class MediumWaveParameters : WaveParameters
{
    private EnemyName[] availableEnemies = new EnemyName[] { EnemyName.Kamikaze, EnemyName.Gunner, EnemyName.Ninja};
    public override EnemyName[] AvailableEnemies => availableEnemies;

    private int[] probabilityCuttofs = new int[] { 50, 90, 100 };
    public override int[] ProbabilityCutoffs => probabilityCuttofs;

    private int minNumberOfEnemies = 20;
    public override int MinNumberOfEnemies => minNumberOfEnemies;

    private int maxNumberOfEnemies = 30;
    public override int MaxNumberOfEnemies => maxNumberOfEnemies;

    private int minSpawnSpeed = 3;
    public override int MinSpawnSpeed => minSpawnSpeed;

    private int maxSpawnSpeed = 11;
    public override int MaxSpawnSpeed => maxSpawnSpeed;
}

public class HardWaveParameters : WaveParameters
{
    private EnemyName[] availableEnemies = new EnemyName[] { EnemyName.Kamikaze, EnemyName.Gunner, EnemyName.Ninja };
    public override EnemyName[] AvailableEnemies => availableEnemies;

    private int[] probabilityCuttofs = new int[] { 20, 60, 100 };
    public override int[] ProbabilityCutoffs => probabilityCuttofs;

    private int minNumberOfEnemies = 30;
    public override int MinNumberOfEnemies => minNumberOfEnemies;

    private int maxNumberOfEnemies = 40;
    public override int MaxNumberOfEnemies => maxNumberOfEnemies;

    private int minSpawnSpeed = 1;
    public override int MinSpawnSpeed => minSpawnSpeed;

    private int maxSpawnSpeed = 7;
    public override int MaxSpawnSpeed => maxSpawnSpeed;
}