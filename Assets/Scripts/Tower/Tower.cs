using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    #region[SerializeField]
    [SerializeField]  protected float attackRange;
    [SerializeField]  protected float attackSpeed;

    [SerializeField]  Transform rotationPoint;
    [SerializeField]  protected LayerMask enemyLayer;
    [SerializeField]  protected GameObject projectilePrefab;
    [SerializeField]  protected Transform attackPoint;
    [SerializeField]  protected Animator animator;
    #endregion

    #region PRIVATE
    protected Transform target;
    protected float additionalAttackPower;
    protected float timeBetweenAttacks;
    protected float timeRemainedBetweenAttacks = 0f;
    private readonly float defaultAttackSpeed = 4f;
    #endregion


    protected virtual void Start()
    {
        timeBetweenAttacks = defaultAttackSpeed - attackSpeed;

        SetAdditionalAttackPower();
    }

    protected virtual void Update()
    {

        if (target == null)
        {
            DetectTarget();

            return;
        }


        RotateTowardsTarget();


        timeRemainedBetweenAttacks -= Time.deltaTime;


        if (timeRemainedBetweenAttacks <= 0)
        {
            Attack();
            timeRemainedBetweenAttacks = timeBetweenAttacks;
        }

        CheckTargetInRange();
    }



    protected virtual void Attack()
    {
        animator.SetTrigger("AttackAnim");

        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

        Projectile projectileScript = projectile.GetComponent<Projectile>();

        projectileScript.SetAdditionalAttackDamage(additionalAttackPower);

        projectileScript.SetTarget(target);
    }

    protected virtual void DetectTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,attackRange,(Vector2)transform.position,0f,enemyLayer);

        if(hits.Length > 0) {

            target = hits[0].transform;  
        }
    }

    protected void RotateTowardsTarget()
    { 
        //Atan2 returns value in radian. must convert it to degree.
        float angle = Mathf.Atan2(target.position.y - transform.position.y,target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotation = Quaternion.Euler(new Vector3(0f ,0f , angle));

        rotationPoint.rotation = rotation;
    }

    protected void CheckTargetInRange()
    {
        if (Vector2.Distance(transform.position, target.position) > attackRange)
        {
            target = null;
        }
    }

    protected virtual void SetAdditionalAttackPower()
    {
        additionalAttackPower = UpgradeSceneManager.towerLevels["ArrowTower"] * ArrowTowerUpgrade.additionalAttackDamagePerLevel;
        print("Additional AD:" + additionalAttackPower);
    }
 
}
