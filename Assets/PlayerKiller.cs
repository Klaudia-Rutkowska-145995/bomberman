using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKiller : MonoBehaviour
{
    public Animator animator;

    private PlayerData playerData;

    public void killPlayer()
    {
        playerData.Killed = true;

        animator.SetBool("Killed", true);
    }

    private void Awake()
    {
        playerData = GetComponent<PlayerData>();
    }
}
