using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PoolFX : MonoBehaviour
{
    public static PoolFX instance;
    public GameObject hitFX, explosionFX;

    public List<GameObject> hits = new List<GameObject>();
    public List<GameObject> explosiones = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    public void SpawnHit(Vector3 pos, Quaternion rot)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < hits.Count; i++)
        {
            if (!hits[i].activeInHierarchy)
            {
                hits[i].transform.position = pos;
                hits[i].transform.rotation = rot;
                hits[i].SetActive(true);
                hayDisponibles = true;
                break;
            }
        }

        if(!hayDisponibles)
        {
            GameObject _hit = Instantiate(hitFX, pos, rot);
            hits.Add(_hit);
        }
    }

    public void SpawnExplosion(Vector3 pos, Quaternion rot)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < explosiones.Count; i++)
        {
            if (!explosiones[i].activeInHierarchy)
            {
                explosiones[i].transform.position = pos;
                explosiones[i].transform.rotation = rot;
                explosiones[i].SetActive(true);
                hayDisponibles = true;
                break;
            }
        }

        if (!hayDisponibles)
        {
            GameObject _explosion = Instantiate(explosionFX, pos, rot);
            explosiones.Add(_explosion);
        }
    }


}
