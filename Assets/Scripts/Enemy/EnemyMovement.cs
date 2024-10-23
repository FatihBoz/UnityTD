using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public static Action<GameObject> OnEnemyPassed;

    public float curseSlowPercentage;
    public float curseTime;

    #region PRIVATE VARIABLES
    private bool isCursed;
    private float remainingCurseTime;
    private float currentSpeed;
    private float maxSpeed;
    private int pathIndex;
    #endregion

    #region REFERENCES  
    private Transform target;
    private Rigidbody2D rb;
    private EnemyAttributes enemyAttributes;
    private Animator animator;
    #endregion

    #region COLORS
    private Color cursedColor;
    private Color defaultColor;
    #endregion


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyAttributes = GetComponent<EnemyAttributes>();
        animator = GetComponent<Animator>();
        defaultColor = GetComponent<SpriteRenderer>().color;
    }

    private void OnEnable()
    {
        pathIndex = 0;
        target = LevelManager.main.path[pathIndex];

        maxSpeed = enemyAttributes.MS;
        currentSpeed = maxSpeed;

        cursedColor = new Color(0.6f, 0.6f, 0.6f);
    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) <= 0.05f)
        {
            pathIndex++;

            if (pathIndex >= LevelManager.main.path.Count)
            {
                OnEnemyPassed?.Invoke(this.gameObject); 
                EnemyAttributes.OnEnemyDied?.Invoke(this.gameObject);
            }
            else
            {
                target = LevelManager.main.path[pathIndex];
            }
        }

        if(isCursed)
        {
            remainingCurseTime -= Time.deltaTime;

            if (remainingCurseTime <= 0)
            {
                EndCurse();
            }
        }
    }

    private void FixedUpdate()     
    {
        Vector2 moveDir = (target.position - transform.position);  

        moveDir = moveDir.normalized;         // Equal displacement for all directions.

        rb.velocity = moveDir * currentSpeed;

        EnemyMovementAnimation();
    }


    public void GetCursed(float damage)
    {
        if (!isCursed)
        {
            StartCurse(damage);
        }
        else
        {
            remainingCurseTime = curseTime;  // If already cursed, refresh the curse time
        }
    }

    private void StartCurse(float damage)
    {
        isCursed = true;

        enemyAttributes.TakeDamage(damage);

        remainingCurseTime = curseTime;

        enemyAttributes.TakeDamage(damage);

        currentSpeed = (1 - curseSlowPercentage) * maxSpeed;

        GetComponent<SpriteRenderer>().color = cursedColor;
    }

    private void EndCurse()
    {
        GetComponent<SpriteRenderer>().color = defaultColor;
        currentSpeed = maxSpeed;
        isCursed = false;
    }

    private void EnemyMovementAnimation()
    {
        animator.SetFloat("Velocity_x",rb.velocity.x);
        animator.SetFloat("Velocity_y", rb.velocity.y);
    }
}
