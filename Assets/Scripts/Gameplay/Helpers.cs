using System;
using UnityEngine;

public static class Helpers
{
    public static Vector3 ToVector(this Direction direction) => direction switch
    {
        Direction.Up => Vector3.up,
        Direction.Right => Vector3.right,
        Direction.Down => Vector3.down,
        Direction.Left => Vector3.left,
        _ => Vector3.zero
    };

    public static Direction GetOpposite(this Direction direction) => direction switch
    {
        Direction.Up => Direction.Down,
        Direction.Right => Direction.Left,
        Direction.Down => Direction.Up,
        Direction.Left => Direction.Right,
        _ => Direction.Down
    };
}

