using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    private bool killed = false;
    private bool attacking = false;

    public bool Killed { get => killed; set => killed = value; }

    public bool Attacking { get => attacking; set => attacking = value; }
}
