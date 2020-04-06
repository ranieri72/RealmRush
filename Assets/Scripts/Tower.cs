using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] Transform objectToPan;
    [SerializeField] Transform targetEnemy;
    [SerializeField] int attackRange = 30;
    [SerializeField] ParticleSystem projectileParticle;

    void Update()
    {
        if (targetEnemy)
        {
            objectToPan.LookAt(targetEnemy);
            FireAtEnemy();
        }
        else
        {
            Shoot(false);
        }
        
    }

    private void FireAtEnemy()
    {
        float distanceToEnemy = Vector3.Distance(
            targetEnemy.transform.position,
            gameObject.transform.position
            );
        if (distanceToEnemy < attackRange)
        {
            Shoot(true);
        }
        else
        {
            Shoot(false);
        }
    }

    private void Shoot(bool isActive)
    {
        var emissionModule = projectileParticle.emission;
        emissionModule.enabled = isActive;
    }
}