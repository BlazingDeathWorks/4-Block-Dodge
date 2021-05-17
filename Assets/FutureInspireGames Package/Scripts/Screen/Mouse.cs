using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames
{
    public static class Mouse
    {
        public static Vector2 GetMousePosScreenspace()
        {
            return new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        public static Vector2 GetMousePosWorld(Camera mainCamera)
        {
            return mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        public static Vector2 GetMousePosViewport(Camera mainCamera)
        {
            return mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
