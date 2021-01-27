using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    public Animator animator;

    private EnemyData enemyData;

    public void killEnemy()
    {
        enemyData.Killed = true;

        animator.SetBool("Killed", true);
    }

    private void Awake()
    {
        enemyData = GetComponent<EnemyData>();
    }
}
