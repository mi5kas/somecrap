using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinate : IEquatable<Coordinate>
{
    int x, y;

    public Coordinate(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public bool Equals(Coordinate other)
    {
        if (this.x == other.x && this.y == other.y)
            return true;
        else return false;
    }
}
