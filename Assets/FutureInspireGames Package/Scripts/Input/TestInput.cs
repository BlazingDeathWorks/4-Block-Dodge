using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class TestInput : MonoBehaviour
    {
        [SerializeField]
        float speed = 1;
        Rigidbody2D rb = null;
        InputMovement2DMode inputMovement2DMode = null;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            inputMovement2DMode = new InputMovement2DMode(rb, InputMovement2DModes.Topdown);
        }

        private void Update()
        {
            InputMovement2D.FindXInputRaw();
            InputMovement2D.FindYInputRaw();
        }

        private void FixedUpdate()
        {
            rb.velocity = InputMovement2D.GetVelocityRaw(speed);
        }
    }
}
