using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Animator animator;

    public GameObject player;

    private EnemyData enemyData;
    private PlayerData playerData;
    private PlayerKiller playerKiller;

    private Vector3 direction;

    void Update()
    {
        if (!playerData.Killed && !enemyData.Killed)
        {
            animator.SetBool("Attacking", false);
            enemyData.Attacking = false;

            if (Vector3.Distance(transform.position, player.transform.position) <= 1f)
            {
                direction = (transform.position - player.transform.position).normalized;

                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
                animator.SetBool("Attacking", true);
                enemyData.Attacking = true;
                playerKiller.killPlayer();
            }
        }
    }

    private void Awake()
    {
        enemyData = GetComponent<EnemyData>();
        playerData = player.GetComponent<PlayerData>();
        playerKiller = player.GetComponent<PlayerKiller>();
    }
}
