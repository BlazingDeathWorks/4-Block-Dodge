using UnityEngine;

public class IPlayerCollisionHandlerManager : MonoBehaviour
{
    private void Awake()
    {
        IPlayerCollisionHandler[] playerCollisionHandlers = (IPlayerCollisionHandler[])FindObjectsOfType(typeof(IPlayerCollisionHandler));
        if (playerCollisionHandlers == null) return;
        foreach(IPlayerCollisionHandler playerCollisionHandler in playerCollisionHandlers)
        {
            PlayerCollision.PlayerCollisionHandler += playerCollisionHandler.OnPlayerCollision;
        }
    }
}
