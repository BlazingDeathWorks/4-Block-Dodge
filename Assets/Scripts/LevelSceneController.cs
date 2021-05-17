using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSceneController : IPlayerCollisionHandler
{
    [SerializeField] SceneTransition sceneTransition = null;

    public override void OnPlayerCollision()
    {
        //StartCoroutine("GameOver");
        sceneTransition.NextScene("Game Over");
    }

    private IEnumerator GameOver()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        sceneTransition.NextScene("Game Over");
    }
}
