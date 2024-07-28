using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Enemy : MonoBehaviour
{
    public float health = 100f;
    public float Dano = 10f;
    public GameObject itemToDrop;
    public int chanceToDrop;
    public float attackRange = 2f;
    public float attackInterval = 1f;
    private float nextAttackTime = 0f;
    public AudioClip[] FootstepAudioClips;
    WaveEnemy Spawner;

    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + attackInterval;
        }
    }


    void Attack()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                Debug.Log("Acertou " + collider.name);
                PlayerDamage player = collider.GetComponent<PlayerDamage>();
                if (player != null)
                {
                    //player.TakeDamage(Dano);
                }
            }
        }
    }
    private void OnFootstep(AnimationEvent animationEvent)
    {
        if (animationEvent.animatorClipInfo.weight > 0.5f)
        {
            if (FootstepAudioClips.Length > 0)
            {
                Debug.Log("Andou");
                var index = Random.Range(0, FootstepAudioClips.Length);
                AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(transform.position), 1);
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber <= chanceToDrop)
        {
            Instantiate(itemToDrop, transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }
}
