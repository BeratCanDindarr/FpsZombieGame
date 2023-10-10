using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombie : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        other.gameObject.GetComponent<IDamageAble>()?.TakeDamage(10);
        //if (other.gameObject.CompareTag("Player"))
        //{
        //    other.gameObject.GetComponent<IDamageAble>().TakeDamage(10);
        //}
    }
}
