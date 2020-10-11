using System;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    public static GameEvent gameEvent;

    private void Awake()
    {
        gameEvent = this;
    }

    public event Action onRoundStart;
    public void RoundStart()
    {
        onRoundStart?.Invoke();
    }

    public event Action onRoundEnd;
    public void RoundEnd()
    {
        onRoundEnd?.Invoke();
    }

    public event Action onDeath;
    public void Death()
    {
        onDeath?.Invoke();
    }

    public event Action onGameEnd;
    public void GameEnd()
    {
        onGameEnd?.Invoke();
    }
}
