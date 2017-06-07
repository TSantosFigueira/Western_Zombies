using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacePool : MonoBehaviour {

    public GameObject poolObject;
    public int poolSize;
    public int maxPoolSize;

	void Start () {
        ObjectPoolingManager.Instance.CreatePool(poolObject, poolSize, maxPoolSize, transform);
	}
}
