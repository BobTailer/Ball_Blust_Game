using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] public float fireRate;
    [SerializeField] public int damage;
    [SerializeField] public int projectileAmount;
    [SerializeField] private float projectileInterval;

    public int Damage => damage;
    public int ProjectileAmount => projectileAmount; 
    public float FireRate => fireRate;

    private float timer;

    private void Awake()
    {
        Load();
    }

    private void Update()
    {
        timer += Time.deltaTime;

        Save();
    }

    private void SpawnProjectile()
    {
        float startPosX = shootPoint.position.x - projectileInterval * (projectileAmount - 1) * 0.5f;

        for (int i = 0; i < projectileAmount; i++)
        {
            Projectile projectile = Instantiate(projectilePrefab, new Vector3(startPosX + i * projectileInterval, shootPoint.position.y, shootPoint.position.z), transform.rotation);
            projectile.SetDamage(damage);
        }
    }

    public void Fire()
    {
        if (timer >= fireRate)
        {
            SpawnProjectile();

            timer = 0;
        }
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("FireRate", fireRate);
        PlayerPrefs.SetInt("Damage", damage);
        PlayerPrefs.SetInt("ProjectileAmount", projectileAmount);
    }

    private void Load()
    {
        fireRate = PlayerPrefs.GetFloat("FireRate", 1);
        damage = PlayerPrefs.GetInt("Damage", 1);
        projectileAmount = PlayerPrefs.GetInt("ProjectileAmount", 1);
    }
}
