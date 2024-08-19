using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private bool levelUpdated = false;
    private int currentLevel = 1;
    public int CurrentLevel => currentLevel;

    private void Awake()
    {
        Load();
        levelUpdated = false;
    }

    private void Update()
    {
        if (LevelState.isPassed == true)
        {
            if (levelUpdated == false)
            {
                currentLevel++;
                Save();
            }
            levelUpdated = true;
        }
        if (Input.GetKeyDown(KeyCode.F1) == true)
        {
            Reset();
        }

        if (Input.GetKeyDown(KeyCode.F2) == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void Save()
    {
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
    }

    protected void Load()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
    }

    private void Reset()
    {
        PlayerPrefs.DeleteAll();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
