using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSetColour : MonoBehaviour
{
    [SerializeField] private Stone stone;
    [SerializeField] private Material stone_material;

    private Color32[] stone_colours = { new Color32(255, 137, 137, 255), new Color32(101, 203, 84, 255), new Color32(170, 170, 170, 255) };

    private int colour_index;

    private void Start()
    {
        colour_index = Random.Range(0, stone_colours.Length);
        stone_material.color = stone_colours[colour_index];
    }
}
