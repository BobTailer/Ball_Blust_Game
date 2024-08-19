using UnityEngine;
using UnityEngine.Events;

public class LevelState : MonoBehaviour
{
    [SerializeField] private StoneSpawner spawner;
    [SerializeField] private Cart cart;

    [Space(5)]
    public UnityEvent Passed;
    public UnityEvent Defeat;

    private float timer;
    private bool checkPassed;

    public static bool isGame = true;
    public static bool isPassed = false;
    public static bool isDefeat = false;

    private void Awake()
    {
        spawner.Completed.AddListener(OnSpawnCompleted);
        cart.CollisionStone.AddListener(OnCartCollisionStone);
    }

    private void OnDestroy()
    {
        spawner.Completed.RemoveListener(OnSpawnCompleted);
        cart.CollisionStone.RemoveListener(OnCartCollisionStone);
    }

    private void OnCartCollisionStone()
    {
        Defeat.Invoke();
        isGame = false;
        isDefeat = true;
    }

    private void OnSpawnCompleted()
    {
        checkPassed = true;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.5f)
        {
            if (checkPassed == true)
            {
                if (FindObjectsOfType<Stone>().Length == 0)
                {
                    Passed.Invoke();
                    isGame = false;
                    isPassed = true;
                }
            }
            timer = 0;
        }
    }
}
