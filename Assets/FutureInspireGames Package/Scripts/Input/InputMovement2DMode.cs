using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace FutureInspireGames
{
    public enum InputMovement2DModes {Platformer, Topdown};

    public class InputMovement2DMode
    {
        public InputMovement2DModes inputMovementMode { get; private set; }

        public InputMovement2DMode(Rigidbody2D rb, InputMovement2DModes mode)
        {
            inputMovementMode = mode;
            switch (inputMovementMode)
            {
                case InputMovement2DModes.Platformer: rb.gravityScale = 1; break;
                case InputMovement2DModes.Topdown: rb.gravityScale = 0; break;
                default: break;
            }
        }

        public InputMovement2DMode(Rigidbody2D rb, float gravityScale, InputMovement2DModes mode)
        {
            inputMovementMode = mode;
            switch (inputMovementMode)
            {
                case InputMovement2DModes.Platformer: rb.gravityScale = gravityScale; break;
                case InputMovement2DModes.Topdown: rb.gravityScale = gravityScale; break;
                default: break;
            }
        }
    }
}
