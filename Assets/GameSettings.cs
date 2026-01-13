using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public static class GameSettings
{
    public static Difficulty CurrentDifficulty = Difficulty.Easy;

    public static int GetCombatTime()
    {
        if (CurrentDifficulty == Difficulty.Easy)
            return 720;
        else if (CurrentDifficulty == Difficulty.Medium)
            return 540;
        else 
            return 360;
    }
}
