using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    #region[SerializeField]

    [Header("Projectile Attributes")]
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float projectileDamage;
    [SerializeField] private float explosionRadius;

    [Header("Other")]
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private GameObject hitEffect;
    #endregion

    #region PRIVATE
    private Rigidbody2D rb;
    private Transform target;
    #endregion



    private void Awake()
    {   
        rb = GetComponent<Rigidbody2D>();   
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetAdditionalAttackDamage(float additionalAD)
    {
        projectileDamage += additionalAD;
    }

    private void FixedUpdate()
    { 
        CheckIfTargetIsActive();
        
        if (target == null)
        {
            return;
        }

        Movement();

        Rotation();
        
    }

    void Movement()
    {  
        
        Vector2 dir = target.position - transform.position;

        dir = dir.normalized;

        rb.velocity = dir * projectileSpeed;
    }

    void Rotation()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

        transform.rotation = rotation;

        // Rotation speed may be necessary.
    }

    void CheckIfTargetIsActive()
    {
        if (!target.gameObject.activeInHierarchy)
        {
            Destroy(gameObject);
        }
    }


    void InstantiateHitEffect(Transform enemy)
    {
        GameObject projectileHitEffect = Instantiate(hitEffect, enemy.position, Quaternion.identity);
        if (!SettingsMenu.sfxOn)
        {
            AudioSource audioSource = projectileHitEffect.GetComponent<AudioSource>();
            audioSource.mute = true;
        }
    }



    private void OnCollisionEnter2D(Collision2D enemy)
    {
        InstantiateHitEffect(enemy.transform);  

        if (explosionRadius > 0f)       //AOE damage
        {
            Collider2D[] colliderHits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, enemyLayer);

            foreach (Collider2D hit in colliderHits)
            {
                EnemyAttributes enemyAttributes = hit.gameObject.GetComponent<EnemyAttributes>();
                enemyAttributes.TakeDamage(projectileDamage);
            }
        }
        else                         //Single target damage
        {
            EnemyAttributes enemyAttributes = enemy.gameObject.GetComponent<EnemyAttributes>();

            enemyAttributes.TakeDamage(projectileDamage);

        }

        Destroy(gameObject);

    }
}
