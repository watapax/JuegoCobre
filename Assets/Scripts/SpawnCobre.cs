using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public class CobrePosition
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public void Spawn()
    {
        float t = 0;
        
    }

}

public class SpawnCobre : MonoBehaviour
{
    public Transform parentCobre;
    public GameObject cobrePrefab;

    public List<GameObject> cobreList = new List<GameObject>();
    public static SpawnCobre instance;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < cobreList.Count; i++)
        {
            cobreList[i].GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void Iniciar()
    {
        for (int i = 0; i < cobreList.Count; i++)
        {
            cobreList[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
    public void Spawnear(Vector3 pos, Vector3 scale, CorreaManager _correaManager, Transform _parent)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < cobreList.Count; i++)
        {
            if (!cobreList[i].activeInHierarchy)
            {
                cobreList[i].transform.position = pos;
                cobreList[i].transform.rotation = Random.rotation;
                //cobreList[i].transform.localScale = scale;
                cobreList[i].GetComponent<CobreBruto>().correaManager = _correaManager;
                cobreList[i].transform.parent = _parent;
                cobreList[i].SetActive(true);
                hayDisponibles = true;
                break;
            }
        }

        if(!hayDisponibles)
        {
            GameObject c = Instantiate(cobrePrefab);
            c.transform.position = pos;
            c.transform.rotation = Random.rotation;
            //c.transform.localScale = scale;
            c.GetComponent<CobreBruto>().correaManager = _correaManager;
            c.transform.parent = _parent;
            c.SetActive(true);
            cobreList.Add(c);
        }
    }



    
}
