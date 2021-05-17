using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BlockCollision : MonoBehaviour
{
    private event Action BlockCollisionEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            BlockCollisionEvent?.Invoke();
        }
    }

    public void Awake()
    {
        Transform parent = transform.parent;
        if (parent == null) return;
        if(parent.TryGetComponent(out BlockCollisionHandler handler))
        {
            BlockCollisionEvent += handler.OnBlockCollision;
        }
    }
}

public abstract class BlockCollisionHandler : MonoBehaviour
{
    public abstract void OnBlockCollision();
}
