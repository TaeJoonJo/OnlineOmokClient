using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmokPanPoint 
{
    public Vector2 Position;

    public GameObject OmokStone;

    public enum PointType
    {
        None,
        White,
        Black
    }

    public PointType Type;

    public OmokPanPoint(Vector2 pos)
    {
        Position = pos;
        Type = PointType.None;
    }
}
