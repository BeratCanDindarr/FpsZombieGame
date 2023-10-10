using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour, IDamageAble
{
    #region Player Health 
    [Header("Character Health")]
    public float Health = 100;
    private float _currentHealth;
    private float _minhealth = 0;
    #endregion

    private void Awake()
    {
        _currentHealth = Health;
    }
    public void TakeDamage(float damage)
    {
        //_currentHealth -= damage;

        _currentHealth = Mathf.Clamp(_currentHealth-damage,_minhealth,Health);
        CheckDie();
    }

    void CheckDie()
    {
        if (_currentHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
