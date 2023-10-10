using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="deneme",menuName = "CreateGun/NewGun")]
public class GunScriptableObjects : ScriptableObject
{
    public float Damage;
    public float Range;
    public float ImpactForce; 
    public float FireRate;
    public int MagazineSize;
    public int AllAmmo;
    public float ReloadTime;
    public bool isReolading = false;
    public ParticleSystem MuzzleFlash;
    public GameObject ImpactEffects;


}
