using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] private float gravity;

    private Vector3 velocity;
    private bool isGravity = true;

    private void Move()
    {
        if (isGravity == true)
        {
            velocity.y -= gravity * Time.deltaTime;


            transform.position += velocity * Time.deltaTime;
        }
    }

    private void Update()
    {
        Move();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelEdge levelEdge = collision.GetComponent<LevelEdge>();

        if (levelEdge != null)
        {
            if (levelEdge.Type == EdgeType.Bottom)
            {
                isGravity = false;
            }
        }
    }
}
