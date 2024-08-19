using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGamePanel : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject passedPanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject shop;

    private void Start()
    {
        defeatPanel.SetActive(false);
        passedPanel.SetActive(false);
        startPanel.SetActive(true);
    }

    private void Update()
    {
        if (LevelState.isGame == false)
        {
            if (LevelState.isDefeat == true && shop.activeSelf == false) defeatPanel.SetActive(true);
            if (LevelState.isPassed == true && shop.activeSelf == false) passedPanel.SetActive(true);
        }
        if (LevelState.isGame == true)
        {
            defeatPanel.SetActive(false);
            passedPanel.SetActive(false);
            startPanel.SetActive(false);
        }
    }
}
