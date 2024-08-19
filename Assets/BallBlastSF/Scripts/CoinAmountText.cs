using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAmountText : MonoBehaviour
{
    [SerializeField] private CoinCollector coinCollector;
    [SerializeField] private Text coinText;

    private void Update()
    {
        coinText.text = "Coins: " + coinCollector.CoinAmount;
    }
}
