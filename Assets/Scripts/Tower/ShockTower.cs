using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ShockTower : Tower
{
    private List<RaycastHit2D> targets;


    protected override void Start()
    {
        base.Start();

        targets = new List<RaycastHit2D>();
    }


    protected override void Update()
    {

        if (timeRemainedBetweenAttacks > 0)
        {
            timeRemainedBetweenAttacks -= Time.deltaTime;
            return;
        }


        DetectTarget();


        if (targets.Count() != 0)
        {
            Attack();
            timeRemainedBetweenAttacks = timeBetweenAttacks;
        }
    }



    protected override void Attack() //shock tower attacks all enemies within its range
    {
        animator.SetTrigger("AttackAnim");

        for (int i = 0; i < targets.Count; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity); //create projectile

            Projectile projectileScript = projectile.GetComponent<Projectile>(); //Access the script

            projectileScript.SetAdditionalAttackDamage(additionalAttackPower); //Set additional attack power according to tower level.

            projectileScript.SetTarget(targets[i].transform);  //Set projectile's target
        }

        targets.Clear();
    }



    protected override void DetectTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position,attackRange,(Vector2)transform.position,0f,enemyLayer);

        if(hits.Length > 0) {

            targets = hits.ToList();  

        }
    }

    protected override void SetAdditionalAttackPower()
    {
        additionalAttackPower = UpgradeSceneManager.towerLevels["ShockTower"] * ShockTowerUpgrade.additionalAttackDamagePerLevel;
        print("Additional AD:" + additionalAttackPower);
    }
}
