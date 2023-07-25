using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager 
{
    public int Score { get; private set; } = 0;

    public UnityEvent<int> ScoreChanged = new UnityEvent<int>();

    public void AddScore(int amount)
    {
        Score += amount;
        ScoreChanged?.Invoke(Score);
    }

    public void RemoveScore(int amount)
    {
        Score -= amount;
        ScoreChanged?.Invoke(Score);
    }

    public void ResetScore()
    {
        Score = 0;
        ScoreChanged?.Invoke(Score);
    }
}
