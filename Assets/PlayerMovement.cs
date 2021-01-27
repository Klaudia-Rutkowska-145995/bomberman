using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;
    public LayerMask EnemiesLayer;
    public LayerMask BombsLayer;

    public Animator animator;

    Vector2 movement;

    private void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<PlayerData>().Killed)
        {
            movement.x = Mathf.RoundToInt(Input.GetAxisRaw("Horizontal"));
            movement.y = Mathf.RoundToInt(Input.GetAxisRaw("Vertical"));

            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(transform.position, movePoint.position) <= .05f)
            {
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                    Vector3 movePos = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);

                    if (
                        !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, whatStopsMovement)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, EnemiesLayer)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, BombsLayer)
                    )
                    {
                        movePoint.position += movePos;
                    }
                }

                if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                    Vector3 movePos = new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);

                    if (
                        !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, whatStopsMovement)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, EnemiesLayer)
                        && !Physics2D.OverlapCircle(movePoint.position + movePos, .2f, BombsLayer)
                    )
                    {
                        movePoint.position += movePos;
                    }
                }

                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
                animator.SetFloat("Speed", movement.sqrMagnitude);
            }
        }
    }
}
