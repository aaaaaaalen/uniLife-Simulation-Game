using UnityEngine;
using System.Collections.Generic;
/**
* @author $Yafei Zhang$
* 
* @date - $2021/5/21$ 
*/
public class SimpleObjectPool : MonoBehaviour
{
    
    public GameObject prefab;
    private Stack<GameObject> inactiveIns = new Stack<GameObject>();

    // get gameobject from prefab
    public GameObject GetObject()
    {
        GameObject newGameObject;

        //check is there is instance avaliable
        if (inactiveIns.Count > 0)
        {

            newGameObject = inactiveIns.Pop();
        }
        else
        {
            //use instantiate to creare new instance base on prefab
            newGameObject = (GameObject)GameObject.Instantiate(prefab);

            PooledObject pooledObject = newGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        newGameObject.SetActive(true);

        return newGameObject;
    }

    // Return an instance to the pool
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        // return instance back to the pool
        if (pooledObject != null && pooledObject.pool == this)
        {
            toReturn.SetActive(false);
            inactiveIns.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasn't spawned from! Destroying.");
            Destroy(toReturn);
        }
    }
}

// object pool
public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}