using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    #region PUBLIC
    public float delayTime;
    public float damageRadius;
    public float baseDamage;
    public Vector3 offSet;
    #endregion

    [SerializeField] LayerMask enemyLayer;

    private Vector3 touchPosition;
    private string skillName;

    private void Start()
    {
        touchPosition = transform.position;
        transform.position += offSet;
    }

    public void InitializeSkill(string skillName)
    {
        this.skillName = skillName;
        StartCoroutine(DamageEnemiesAfterDelay());
    }

    IEnumerator DamageEnemiesAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);

        DealDamage();
    }


    private void DealDamage()
    {
        int level = UpgradeSceneManager.skillLevels[skillName];

        float damage = level * (baseDamage + SkillUpgrade.additionalAttackDamagePerLevel);

        Collider2D[] enemies = Physics2D.OverlapCircleAll(touchPosition, damageRadius, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            EnemyAttributes enemyAttributes = enemy.gameObject.GetComponent<EnemyAttributes>();

            enemyAttributes.TakeDamage(damage);
        }

        Destroy(gameObject);
    }




}
