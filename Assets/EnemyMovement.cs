using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask PlayerLayer;
    public LayerMask BombsLayer;

    public Animator animator;

    public GameObject player;

    public float runTime = 0.2f;

    private Vector2 movement;

    float CurrentRunTime = 0.0f;

    private void Start()
    {
        movePoint.parent = null;
    }

    void Update()
    {
        if (!GetComponent<EnemyData>().Killed && !GetComponent<EnemyData>().Attacking)
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            CurrentRunTime += Time.deltaTime;

            if (CurrentRunTime >= runTime)
            {
                if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
                {
                    generateRandomPosition();

                    Vector3 movePos = new Vector3(movement.x, movement.y, 0);

                    if (
                        !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, whatStopsMovement)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, PlayerLayer)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, BombsLayer)
                        && movePos != (movePoint.position - movePos)
                    )
                    {
                        movePoint.position += movePos;

                        animator.SetFloat("Horizontal", movement.x);
                        animator.SetFloat("Vertical", movement.y);
                        animator.SetFloat("Speed", movement.sqrMagnitude);
                    }
                }

                CurrentRunTime = 0.0f;
            }
        }
    }

    void generateRandomPosition()
    {
        movement.x = Random.Range(-1, 2);
        movement.y = Random.Range(-1, 2);

        if (movement.x == 0f)
        {
            movement.y = Random.Range(-1, 2);
        }
        else
        {
            movement.y = 0f;
        }


        if (movement.y == 0f)
        {
            movement.x = Random.Range(-1, 2);
        }
        else
        {
            movement.x = 0f;
        }
    }
}
