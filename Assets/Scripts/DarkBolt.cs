using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class DarkBolt : MonoBehaviour
{
    public float delayTime = 1f;
    public Vector3 offSet;

    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float explosionRadius;

    private Vector3 castPosition;
    private float additionalAttackPower;


    private void Start()
    {
        castPosition = transform.position;
        transform.position += offSet;

        InitializeSkill();
    }


    public void SetAdditionalPowerUps(float damage)
    {
        additionalAttackPower = damage;
    }


    public void InitializeSkill()
    {
        StartCoroutine(DamageEnemiesAfterDelay());
    }


    IEnumerator DamageEnemiesAfterDelay()
    {
        yield return new WaitForSeconds(delayTime); 

        DealDamage();
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(castPosition, explosionRadius);
    }


    private void DealDamage()
    {
        float damage = projectileDamage + additionalAttackPower;

        Collider2D[] enemies = Physics2D.OverlapCircleAll(castPosition, explosionRadius, enemyLayer);

        foreach (Collider2D enemy in enemies)
        {
            EnemyMovement enemyMovement = enemy.gameObject.GetComponent<EnemyMovement>();

            enemyMovement.GetCursed(damage);
        }

        Destroy(this.gameObject);
    }
}
