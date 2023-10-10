using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Selected Gun")]
    public GunScriptableObjects gun;

    [Header("Player Cam")]
    public Camera fpsCam;

    
    public ParticleSystem muzzleFlash;
    #region Gun Animation
    private Animator _animator;
    #endregion

    #region Gun Properties
    private int currentAmmo = -1;
    private bool isReolading = false;
    private float nextTimeToFire = 0f;
    private bool fire;
    #endregion

    #region Delegate
    public delegate void clickFireButton(bool clicked);
    public static clickFireButton ClickFire;
    #endregion

    #region Gun Animation Name
    [SerializeField] private const string _reloading = "Reloading";
    [SerializeField] private const string _fire = "Fire";
    

    #endregion
    private void Awake()
    {
        ClickFire += ClickButton;
        _animator = GetComponent<Animator>();
        
    }
    private void Start()
    {
        if(currentAmmo == -1)
        currentAmmo = gun.MagazineSize;
        
    }
    private void OnEnable()
    {
        isReolading = false;
        ChangeAnim(_reloading, false);
        currentAmmo = gun.MagazineSize;
    
        
    }
    
    void ClickButton(bool clicked)
    {
        fire = clicked;
    }
    

    void Update()
    {
        if (isReolading)
        {
            return;
        }
        if (currentAmmo <=0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (fire && Time.time >= nextTimeToFire)
        {
            ChangeAnim(_fire, true);
            nextTimeToFire = Time.time + 1f / gun.FireRate;
            Shoot();
        }
        else
        {
            ChangeAnim(_fire, false);
        }
    }


    
    IEnumerator Reload()
    {
        isReolading = true;
        Debug.Log("Reolading ...");
        ChangeAnim(_reloading, true);
        yield return new WaitForSeconds(gun.ReloadTime - 0.30f);
        ChangeAnim(_reloading, false);
        yield return new WaitForSeconds(0.30f); 
        currentAmmo = gun.MagazineSize;
        isReolading = false;
    }
    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out hit, gun.Range))
        {
            ZombieDamage target = hit.transform.GetComponent<ZombieDamage>();
            FXName particalEnumName = FXName.DEFAULT;
            if (target != null)
            {
                target.TakeDamage(gun.Damage);
                particalEnumName = FXName.BLOODFX;
            }
            else
            {
                particalEnumName = FXName.BLUTIMPACT;

            }
            if (hit.rigidbody !=null)
            {
                hit.rigidbody.AddForce(-hit.normal*gun.ImpactForce);
            }
            //GameObject impactGO= Instantiate(gun.ImpactEffects, hit.point, Quaternion.LookRotation(hit.normal));
            GameObject impactGO = null;
            impactGO = PoolManager.ReturnObject(PoolObjectName.PARTICALS, particalEnumName);
            impactGO.transform.position = hit.point;
            impactGO.SetActive(true);
            impactGO.transform.rotation = Quaternion.LookRotation(hit.normal);
            StartCoroutine(ReturnGunImpact(impactGO,particalEnumName));
        }
    }
    IEnumerator ReturnGunImpact(GameObject _impact, FXName _particalName)
    {
        yield return new WaitForSeconds(0.25f);
        _impact.SetActive(false);
        PoolManager.SetObject(PoolObjectName.PARTICALS,_particalName, _impact);
    }


    private void ChangeAnim(string animName , bool isActive)
    {
        _animator.SetBool(animName, isActive);
    }

    private void OnDisable()
    {
        ChangeAnim(_reloading,false);
        //_animator.SetBool("Reloading", false);
        gun.isReolading = false;
        ClickFire += ClickButton;
    }

}
