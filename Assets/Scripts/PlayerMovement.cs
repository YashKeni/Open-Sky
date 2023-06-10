using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;

    Vector2 movementInput;
    Rigidbody2D rigidBody;
    Animator animator;
    SwordAttack swordAttack;

    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        swordAttack = FindObjectOfType<SwordAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (DialogueManager.isActive == true)
            return;
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movementInput.x);
        animator.SetFloat("Vertical", movementInput.y);
        animator.SetFloat("Speed", movementInput.sqrMagnitude);

        if (Input.GetMouseButtonDown(button: 0))
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            rigidBody.MovePosition(rigidBody.position + movementInput * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Attack()
    {
        if (animator.GetFloat("Speed") == 0)
        {
            animator.SetTrigger("isAttackingDown");
        }

        if (animator.GetFloat("Speed") == 1 &&
            animator.GetFloat("Vertical") == -1 &&
            animator.GetFloat("Horizontal") == 0)
        {
            animator.SetTrigger("isAttackingDown");
        }

        if (animator.GetFloat("Speed") == 1 &&
            animator.GetFloat("Vertical") == 1 &&
            animator.GetFloat("Horizontal") == 0)
        {
            animator.SetTrigger("isAttackingUp");
        }

        if (animator.GetFloat("Speed") == 1 &&
            animator.GetFloat("Vertical") == 0 &&
            animator.GetFloat("Horizontal") == 1)
        {
            animator.SetTrigger("isAttackingRight");
        }

        if (animator.GetFloat("Speed") == 1 &&
            animator.GetFloat("Vertical") == 0 &&
            animator.GetFloat("Horizontal") == -1)
        {
            animator.SetTrigger("isAttackingLeft");
        }
    }

    public void LockMovement()
    {
        canMove = false;
    }

    public void UnlockMovement()
    {
        canMove = true;
    }

    public void Hit()
    {
        swordAttack.InitiateAttack();
    }

    public void StopHit()
    {
        swordAttack.StopAttack();
    }
}





