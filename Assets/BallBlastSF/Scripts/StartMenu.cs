using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject cart;
    [SerializeField] private GameObject stoneSpawner;

    private void Start()
    {
        LevelState.isGame = false;
        cart.transform.GetComponent<CartInputControl>().enabled = false;
        stoneSpawner.SetActive(false);
    }
}
