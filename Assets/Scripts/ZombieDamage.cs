using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDamage : MonoBehaviour,IDamageAble
{
    public ZombiePart zombiePart;
    public ZombieAI zombieAi;
  
    public void TakeDamage(float amount)
    {
        zombieAi.DamageZombie(zombiePart,amount);
    }

}
