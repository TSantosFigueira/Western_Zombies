using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : IComparable<PlayerScore> {

    public string playerName;
    public int score;

    public static int localScore;

    public int CompareTo(PlayerScore other)
    {
        return score.CompareTo(other.score);
    }
}
