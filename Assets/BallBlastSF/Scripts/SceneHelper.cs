using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    [SerializeField] private GameObject cart;
    [SerializeField] private GameObject stoneSpawner;
    [SerializeField] private GameObject manager;

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        LevelState.isGame = true;
        LevelState.isDefeat = false;
        LevelState.isPassed = false;
        manager.GetComponent<StartMenu>().enabled = false;
    }

    public void StartLevel()
    {
        LevelState.isGame = true;
        cart.transform.GetComponent<CartInputControl>().enabled = true;
        stoneSpawner.SetActive(true);
        manager.GetComponent<StartMenu>().enabled = false;
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
