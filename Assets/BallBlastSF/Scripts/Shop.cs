using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private Turret turret;
    [SerializeField] private CoinCollector coins;

    [Header("Texts")]
    [SerializeField] private Text FireRateLevelText;
    [SerializeField] private Text FireRateUpgradeCostText;
    [SerializeField] private Text DamageLevelText;
    [SerializeField] private Text DamageUpgradeCostText;
    [SerializeField] private Text BulletsLevelText;
    [SerializeField] private Text BulletsUpgradeCostText;

    [Header("Buttons")]
    [SerializeField] private GameObject FireRateButton;
    [SerializeField] private GameObject DamageButton;
    [SerializeField] private GameObject BulletsButton;

    private int FireRateLevel = 1;
    private int FireRateUpgradeCost;
    private int DamageLevel = 1;
    private int DamageUpgradeCost;
    private int BulletsLevel = 1;
    private int BulletsUpgradeCost;

    private int FireRateMaxLevel = 20;
    private int DamageMaxLevel = 100;
    private int BulletsMaxLevel = 20;

    private float FireRateDelta = 0.05f;
    private int DamageDelta = 2;
    private int BulletsDelta = 1;

    private void Awake()
    {
        Load();
    }

    private void Update()
    {
        FireRateLevelText.text = "Level: " + FireRateLevel.ToString();
        DamageLevelText.text = "Level: " + DamageLevel.ToString();
        BulletsLevelText.text = "Level: " + BulletsLevel.ToString();

        if (FireRateLevel == FireRateMaxLevel)
        {
            FireRateLevelText.text = "Max";
            FireRateUpgradeCostText.gameObject.SetActive(false);
            FireRateButton.SetActive(false);
        }

        if (DamageLevel == DamageMaxLevel)
        {
            DamageLevelText.text = "Max";
            DamageUpgradeCostText.gameObject.SetActive(false);
            DamageButton.SetActive(false);
        }

        if (BulletsLevel == BulletsMaxLevel)
        {
            BulletsLevelText.text = "Max";
            BulletsUpgradeCostText.gameObject.SetActive(false);
            BulletsButton.SetActive(false);
        }

        FireRateUpgradeCost = FireRateLevel * 15;
        DamageUpgradeCost = DamageLevel * 3;
        BulletsUpgradeCost = BulletsLevel * 20;

        FireRateUpgradeCostText.text = FireRateUpgradeCost.ToString();
        DamageUpgradeCostText.text = DamageUpgradeCost.ToString();
        BulletsUpgradeCostText.text = BulletsUpgradeCost.ToString();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("FireRateLevel", FireRateLevel);
        PlayerPrefs.SetInt("DamageLevel", DamageLevel);
        PlayerPrefs.SetInt("BulletsLevel", BulletsLevel);
    }

    private void Load()
    {
        FireRateLevel = PlayerPrefs.GetInt("FireRateLevel", 1);
        DamageLevel = PlayerPrefs.GetInt("DamageLevel", 1);
        BulletsLevel = PlayerPrefs.GetInt("BulletsLevel", 1);
    }

    public void UpgradeFireRate()
    {
        if (coins.CoinAmount > FireRateUpgradeCost)
        {
            coins.Buy(FireRateUpgradeCost);
            turret.fireRate -= FireRateDelta;
            FireRateLevel++;
            Save();
        }
    }

    public void UpgradeDamage()
    {
        if (coins.CoinAmount > DamageUpgradeCost)
        {
            coins.Buy(DamageUpgradeCost);
            turret.damage += DamageDelta;
            DamageLevel++;
            Save();
        }
    }

    public void UpgradeBullets()
    {
        if (coins.CoinAmount > BulletsUpgradeCost)
        {
            coins.Buy(BulletsUpgradeCost);
            turret.projectileAmount += BulletsDelta;
            BulletsLevel++;
            Save();
        }
    }
}
