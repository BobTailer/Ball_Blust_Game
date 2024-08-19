using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    private int coinsAmount;
    public int CoinAmount => coinsAmount;

    private void Awake()
    {
        Load();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Coin coin = collision.transform.root.GetComponent<Coin>();

        if (coin != null)
        {
            Destroy(coin.gameObject);
            coinsAmount++;
            Save();
        }
    }

    public void Buy(int cost)
    {
        coinsAmount -= cost;
        Save();
    }

    private void Save()
    {
        PlayerPrefs.SetInt("CoinsAmount", coinsAmount);
    }

    protected void Load()
    {
        coinsAmount = PlayerPrefs.GetInt("CoinsAmount", 0);
    }
}
