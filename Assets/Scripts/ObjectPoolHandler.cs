using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolHandler : MonoBehaviour {

    public GameObject prefab;

    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        if (inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);

            // menambahkan komponen PooledObject kepada prefab untuk menandakan prefab tersebut berasal dari pool ini
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        // memasukkan instance ke dalam scene dan mengaktifkannya
        spawnedGameObject.transform.SetParent(null);
        spawnedGameObject.SetActive(true);

        return spawnedGameObject;
    }

    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        if (pooledObject != null && pooledObject.pool == this)
        {
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            inactiveInstances.Push(toReturn);
        }
        else
        {
            Destroy(toReturn);
        }
    }
}

// komponen tambahan yang berfungsi untuk mengidentifikasi dari pool mana sebuah GameObject berasal
public class PooledObject : MonoBehaviour
{
    public ObjectPoolHandler pool;
}