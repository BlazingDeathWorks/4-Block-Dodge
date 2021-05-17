using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames
{
    public static class InputMovement2D
    {
        //Variables
        private const string horizontal = "Horizontal";
        private const string vertical = "Vertical";
        private static float HorizontalValue { get; set; }
        private static float VerticalValue { get; set; }
        private static float HorizontalValueRaw { get; set; }
        private static float VerticalValueRaw { get; set; }

        //Find Inputs ----------------------------------------------------------------------------------------------------------------------------------------

        public static float FindXInput()
        {
            HorizontalValue = Input.GetAxis(horizontal);
            return HorizontalValue;
        }

        public static float FindXInputRaw()
        {
            HorizontalValueRaw = Input.GetAxisRaw(horizontal);
            return HorizontalValueRaw;
        }

        public static float FindYInput()
        {
            VerticalValue = Input.GetAxis(vertical);
            return VerticalValue;
        }

        public static float FindYInputRaw()
        {
            VerticalValueRaw = Input.GetAxisRaw(vertical);
            return VerticalValueRaw;
        }

        //Get Value --------------------------------------------------------------------------------------------------------------------------------------

        public static float GetHorizontalValue()
        {
            return HorizontalValue;
        }

        public static float GetHorizontalValueRaw()
        {
            return HorizontalValueRaw;
        }

        public static float GetVerticalValue()
        {
            return VerticalValue;
        }

        public static float GetVerticalValueRaw()
        {
            return VerticalValueRaw;
        }

        //Get Vector ----------------------------------------------------------------------------------------------------------------------------------------

        public static Vector2 GetVelocity(InputMovement2DMode inputMovementMode, float speed = 1)
        {
            if (inputMovementMode.inputMovementMode != InputMovement2DModes.Topdown) return new Vector2(HorizontalValue, VerticalValue) * speed;
            Vector2 normalizedVector = new Vector2(HorizontalValue, VerticalValue).normalized;
            return normalizedVector * speed;
        }

        public static Vector2 GetVelocity(float speed = 1)
        {
            return new Vector2(HorizontalValue, VerticalValue) * speed;
        }

        public static Vector2 GetVelocityRaw(InputMovement2DMode inputMovementMode, float speed = 1)
        {
            if (inputMovementMode.inputMovementMode != InputMovement2DModes.Topdown) return new Vector2(HorizontalValueRaw, VerticalValueRaw) * speed;
            Vector2 normalizedVector = new Vector2(HorizontalValueRaw, VerticalValueRaw).normalized;
            return normalizedVector * speed;
        }

        public static Vector2 GetVelocityRaw(float speed = 1)
        {
            return new Vector2(HorizontalValueRaw, VerticalValueRaw) * speed;
        }
    }
}
