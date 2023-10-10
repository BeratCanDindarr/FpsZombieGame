using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public enum PoolObjectName
    {
        PARTICALS,
        ZOMBIE,
        DEFAULT
    }
public enum FXName
{
    BLUTIMPACT,
    BLOODFX,
    DEFAULT
}
public class PoolManager : MonoBehaviour
{
    public List<PoolScriptableObject> pools;


    public delegate GameObject returnObject(PoolObjectName poolObjectName, FXName fXName);
    public static returnObject ReturnObject;
    public delegate void setObject(PoolObjectName poolObjectName, FXName fXName, GameObject _object);
    public static setObject SetObject;

    void Start()
    {
        PoolCreate();
        ReturnObject += ReturnGameObject;
        SetObject += SetGameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PoolCreate()
    {
        foreach (var poolObject in pools)
        {
            foreach (var obje in poolObject.pools)
            {
                for (int i = 0; i < obje.Size; i++)
                {
                    Debug.Log(obje.Prefab);
                    GameObject a = Instantiate(obje.Prefab,gameObject.transform.position,gameObject.transform.rotation);
                    a.SetActive(false);
                    obje.Prefabs.Add(a);
                }
            }
        }
    }

    public GameObject ReturnGameObject(PoolObjectName poolObjectName,FXName fXName)
    {
        int selectedList = ((int)poolObjectName);
        int selectedFx = ((int)fXName);
        Debug.Log(selectedList+ " "+selectedFx);
        GameObject returnGameObject = pools[selectedList].pools[selectedFx].Prefabs[0];
        pools[selectedList].pools[selectedFx].Prefabs.RemoveAt(0);
        //foreach (var obj in pools[selectedList].pools[selectedFx].Prefabs)
        //{
        //    if (obj.active == false)
        //    {
        //        returnGameObject = obj;
        //        break;
        //    }
        //}

        return returnGameObject;
    }
    public void SetGameObject(PoolObjectName poolObjectName, FXName fXName, GameObject _object)
    {
        int selectedList = ((int)poolObjectName);
        int selectedFx = ((int)fXName);
        pools[selectedList].pools[selectedFx].Prefabs.Add(_object);

    }
    void PoolDestroy()
    {
        foreach (var poolObject in pools)
        {
            foreach (var obje in poolObject.pools)
            {
                obje.Prefabs.Clear();
            }
        }
    }

    private void OnDestroy()
    {
        PoolDestroy();
        ReturnObject -= ReturnGameObject;
        SetObject -= SetGameObject;
    }
}
