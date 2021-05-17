using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMovement : MonoBehaviour
{
    public static float moveSpeed = 3;
    private const float originalMoveSpeed = 3;

    private void Awake()
    {
        moveSpeed = originalMoveSpeed;
    }

    void Update()
    {
        Vector3 moveVector = new Vector3(moveSpeed, 0, 0);
        transform.Translate(moveVector * Time.deltaTime);
    }
}
