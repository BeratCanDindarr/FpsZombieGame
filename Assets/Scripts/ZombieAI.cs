using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ZombiePart{
    Body,
    Head,
}
public class ZombieAI : MonoBehaviour
{
    public float health;
    ZombieDamage[] zombieDamageAbleParts;
    public GameObject baseZombie;
    NavMeshAgent agent;
    public Transform Target;
    public Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        agent = baseZombie.GetComponent<NavMeshAgent>();
        zombieDamageAbleParts = GetComponentsInChildren<ZombieDamage>();
        AddZombieAi();
    }

    void AddZombieAi()
    {
        if (zombieDamageAbleParts != null)
        {
            foreach (var zombieParts in zombieDamageAbleParts)
            {
                zombieParts.zombieAi = gameObject.GetComponent<ZombieAI>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Target.position);
        //float distance = Vector3.Distance(gameObject.transform.position,Target.position);
        float distance = agent.remainingDistance;
       
        transform.LookAt(Target);

        anim.SetFloat("AttackSize",agent.remainingDistance);
    }

    public void DamageZombie(ZombiePart zombiePart, float damage)
    {
        switch (zombiePart)
        {
            case ZombiePart.Head:
                damage *= 1.5f;
                break;
            default:
                break;
        }
        health -= damage;
        CheckDie(health);
    }

    void CheckDie(float _health)
    {
        if (health <= 0)
        {
            Destroy(baseZombie.gameObject);
        }
    }

   
}
