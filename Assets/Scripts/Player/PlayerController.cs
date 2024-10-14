using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed;
    private bool isMoving;
    private Vector2 input;
    
    [Header("Components")]
    private Animator animator;

    [Header("Collision Variables")]
    public LayerMask solidObjectLayer;
    public LayerMask grassLayer;

    public event Action OnEncounter;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void HandleUpdate()
    {
        if (! isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Removes diagonal movement!
            if (input.x != 0) input.y = 0;

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (IsWalkable(targetPos))
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        
        animator.SetBool("isMoving", isMoving);

    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;

        CheckForEncounters();

    }
        
    private bool IsWalkable (Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer) != null) 
        {
            return false;
        }

        return true;
    }

    private void CheckForEncounters()
    {
        if  (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            if (UnityEngine.Random.Range(1, 101) <= 10)
            {
                animator.SetBool("isMoving", false);
                OnEncounter();
            }
        }
    }
}
