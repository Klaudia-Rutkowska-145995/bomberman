using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private bool killed = false;

    public bool Killed { get => killed; set => killed = value; }
}
