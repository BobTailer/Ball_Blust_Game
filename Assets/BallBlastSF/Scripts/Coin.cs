using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CoinMovement))]
public class Coin : MonoBehaviour
{
    private CoinMovement movement;

    private void Awake()
    {
        movement = GetComponent<CoinMovement>();
    }
}
