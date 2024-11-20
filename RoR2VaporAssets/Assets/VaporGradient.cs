using UnityEngine;
using System;

namespace RoR2Vapor.Implementation
{

[Serializable]
public class VaporGradient
{
    public float Start;
    public float End = 100;

    public Gradient Gradient = new Gradient();
}

}