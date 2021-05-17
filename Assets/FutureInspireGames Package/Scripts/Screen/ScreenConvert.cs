using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FutureInspireGames
{
    public static class ScreenConvert
    {
        public static Vector2 PixelToWorld(Vector2 input, Camera mainCamera, float offset = 90)
        {
            return new Vector2(input.x / (mainCamera.orthographicSize * 4 - 3) - offset, input.y / (mainCamera.orthographicSize * 2) - offset);
        }
    }
}
