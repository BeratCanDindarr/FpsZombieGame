using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//[CreateAssetMenu(menuName ="Create/newPool",fileName ="newPool")]
[System.Serializable]
public class PoolScriptableObject 
{
    [System.Serializable]
    public  struct pool
    {
        public string Name;
        public int Size;
        public GameObject Prefab;
        public List<GameObject> Prefabs;
    }

    public string PoolName;
    public List<pool> pools;
    
}
