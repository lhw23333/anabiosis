using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PoolDate
{
    //挂载的父节点
    public GameObject fatherObj;
    //对象的容器
    public List<GameObject> poolList;

    public PoolDate(GameObject obj,GameObject poolObj)//传入缓存对象和父节点pool
    {
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;

        poolList = new List<GameObject>() { };
        PushObj(obj);
    }

    public void PushObj(GameObject obj)
    {
        obj.SetActive(false);
        poolList.Add(obj);
        obj.transform.parent = fatherObj.transform;     
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }
}

public class PoolManager : BaseManager<PoolManager>
{
    public Dictionary<string, PoolDate> poolDic = new Dictionary<string, PoolDate>();

    public GameObject poolObj;

    public GameObject GetObj(string name)//Get的对象名
    {
        GameObject obj = null;
        //从列表中取出
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            obj = poolDic[name].GetObj();
            
        }
        //空列表，重新生成
        else
        {
            obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            obj.name = name;
        }

        
       
       
        return obj;
    }

    public void PushObj(string name, GameObject obj)//Push的对象名和
    {
        if (poolObj == null)
            poolObj = new GameObject("Pool");
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].PushObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolDate(obj,poolObj));
        }
    }
    //清空缓存池
    //主要用于场景切换
    public void Clear() 
    {
        poolDic.Clear();
        poolObj = null;
    }
}
