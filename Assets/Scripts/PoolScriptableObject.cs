using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName ="Create/newPool",fileName ="newPool")]
public class PoolScriptableObject : ScriptableObject
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
