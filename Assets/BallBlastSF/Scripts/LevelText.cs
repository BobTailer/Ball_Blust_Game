using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    [SerializeField] private LevelProgress levelProgress;
    [SerializeField] private Text levelText;

    private void Update()
    {
        levelText.text = "Level: " + levelProgress.CurrentLevel.ToString();
    }
}