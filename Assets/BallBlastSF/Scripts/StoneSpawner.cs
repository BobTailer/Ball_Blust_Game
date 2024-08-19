using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoneSpawner : MonoBehaviour
{
    [Header("Spawn")]
    [SerializeField] private Stone stonePrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnRate;
    [SerializeField] private LevelProgress levelProgress;

    [Header("Balance")]
    [SerializeField] private int amount;
    [SerializeField] private Turret turret;
    [SerializeField][Range(0.0f, 1.0f)] private float minHitpointsPercentage;
    [SerializeField] private float maxHitpointsRate;

    [Space(10)] public UnityEvent Completed;

    private float timer;
    private float amountSpawned;
    private int stoneMaxHitpoints;
    private int stoneMinHitpoints;

    public static List<GameObject> stones = new List<GameObject>();
    private void Start()
    {
        int damagePerSecond = (int)( (turret.Damage * turret.ProjectileAmount) * (1 / turret.FireRate) );

        stoneMaxHitpoints = (int)(damagePerSecond * maxHitpointsRate);
        stoneMinHitpoints = (int)(stoneMaxHitpoints * minHitpointsPercentage);

        if (stoneMinHitpoints < 1) stoneMinHitpoints = 1;

        timer = spawnRate;

        amount = levelProgress.CurrentLevel;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnRate)
        {
            Spawn();

            timer = 0;
        }

        if (amountSpawned == amount)
        {
            enabled = false;   

            Completed.Invoke();
        }
    }

    private void Spawn()
    {
        Stone stone = Instantiate(stonePrefab, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        stone.SetSize((Stone.Size) Random.Range(1, 4));
        stone.MaxHitPoints = Random.Range(stoneMinHitpoints, stoneMaxHitpoints + 1);

        stones.Add(stone.gameObject);

        amountSpawned++;
    }
}
