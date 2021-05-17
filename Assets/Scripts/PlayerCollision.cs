using UnityEngine;
using System;

public class PlayerCollision : MonoBehaviour
{
    public static event Action PlayerCollisionHandler;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerCollisionHandler?.Invoke();
    }
}
