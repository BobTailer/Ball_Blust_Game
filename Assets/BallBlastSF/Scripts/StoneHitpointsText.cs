using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Destructible))]
public class StoneHitpointsText : MonoBehaviour
{
    [SerializeField] private Text hitpointsText;

    private Destructible destructible;

    private void Awake()
    {
        destructible = GetComponent<Destructible>();
        destructible.ChangeHitPoints.AddListener(OnChangeHitpoints);
    }

    private void OnDestroy()
    {
        destructible.ChangeHitPoints.RemoveListener(OnChangeHitpoints);
    }

    private void OnChangeHitpoints()
    {
        int hitpoints = destructible.GetHitPoints();

        if (hitpoints >= 1000)
        {
            hitpointsText.text = (hitpoints / 1000).ToString() + "K";
        }
        else
        {
            hitpointsText.text = hitpoints.ToString();
        }
    }
}
