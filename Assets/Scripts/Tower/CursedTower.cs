using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CursedTower : Tower
{
    protected override void Update()
    {

        if (target == null)
        {
            DetectTarget();

            return;
        }


        timeRemainedBetweenAttacks -= Time.deltaTime;


        if (timeRemainedBetweenAttacks <= 0)
        {
            Attack();
            timeRemainedBetweenAttacks = timeBetweenAttacks;
        }

        CheckTargetInRange();

    }



    protected override void Attack()
    {
        animator.SetTrigger("Attack");

        Instantiate(projectilePrefab, target.position, Quaternion.identity);
    }


    protected override void SetAdditionalAttackPower()
    {
        additionalAttackPower = UpgradeSceneManager.towerLevels["CursedTower"] * CursedTowerUpgrade.additionalAttackDamagePerLevel;
        print("Additional AD:" + additionalAttackPower);
    }

}
