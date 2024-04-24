using System;
using Fusion;
using UnityEngine;

[Serializable]
public class TestNetworked
{
    [field: SerializeField] [Networked] public int Score { get; private set; }
}