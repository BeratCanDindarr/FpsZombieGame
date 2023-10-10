using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public GameObject AttackHand;
    
    public float distance;
   public void AttackOn()
    {
        AttackHand.SetActive(true);
    }
    public void AttackOff()
    {
        AttackHand.SetActive(false);
    }
}
