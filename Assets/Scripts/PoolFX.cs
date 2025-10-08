using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.MeshOperations;

public class PoolFX : MonoBehaviour
{
    public Transform objectParents;
    public static PoolFX instance;
    public GameObject hitFX, explosionFX, explosionFX2, explosionFX3;

    public List<GameObject> hits = new List<GameObject>();
    public List<GameObject> explosiones, explosiones2, explosiones3 = new List<GameObject>();

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

        if (!hayDisponibles)
        {
            GameObject _hit = Instantiate(hitFX, pos, rot);
            _hit.transform.parent = objectParents;
            hits.Add(_hit);
        }
    }

    public void SpawnExplosion(Vector3 pos, Quaternion rot)
    {
        if(GameManagerOleadas.instance.nivel == 0)
        {
            Explo1(pos, rot);
        }
        if(GameManagerOleadas.instance.nivel == 1)
        {
            Explo2(pos, rot);
        }
        if(GameManagerOleadas.instance.nivel > 1)
        {
            Explo3(pos, rot);
        }

    }

    void Explo1(Vector3 pos, Quaternion rot)
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
            _explosion.transform.parent = objectParents;
            explosiones.Add(_explosion);
        }
    }
    void Explo2(Vector3 pos, Quaternion rot)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < explosiones2.Count; i++)
        {
            if (!explosiones2[i].activeInHierarchy)
            {
                explosiones2[i].transform.position = pos;
                explosiones2[i].transform.rotation = rot;
                explosiones2[i].SetActive(true);
                hayDisponibles = true;
                break;
            }
        }

        if (!hayDisponibles)
        {
            GameObject _explosion = Instantiate(explosionFX2, pos, rot);
            _explosion.transform.parent=objectParents;
            explosiones2.Add(_explosion);
        }
    }
    void Explo3(Vector3 pos, Quaternion rot)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < explosiones3.Count; i++)
        {
            if (!explosiones3[i].activeInHierarchy)
            {
                explosiones3[i].transform.position = pos;
                explosiones3[i].transform.rotation = rot;
                explosiones3[i].SetActive(true);
                hayDisponibles = true;
                break;
            }
        }

        if (!hayDisponibles)
        {
            GameObject _explosion = Instantiate(explosionFX3, pos, rot);
            _explosion.transform.parent = objectParents;
            explosiones3.Add(_explosion);
        }
    }


}
