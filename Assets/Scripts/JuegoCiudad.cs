using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

[System.Serializable]
public class SplinesOleadas
{
    public SplineContainer[] splines;
    public SplineContainer SplineRandom
    {
        get { return splines[Random.Range(0, splines.Length)]; }
    }
}

public class JuegoCiudad : MonoBehaviour
{
    public Animator animCamara;
    public GameObject virusPrefab;

    public SplinesOleadas[] splinesOleadas;
    public List<GameObject> virusSpawneados = new List<GameObject>();
    public float spawnFreq = 1;

    float tiempoEntreSpawn;
    float nextTimeSpawn;
    public GameObject[] mensajes;

    private void Start()
    {
        CalcularFrecuenciaSpawn();
    }

    void CalcularFrecuenciaSpawn()
    {
        tiempoEntreSpawn = 1 / spawnFreq;
    }

    public bool desactivar;

    public void SpawnearVirus()
    {

            /*
            GameObject virus = Instantiate(virusPrefab);
            virus.GetComponent<Virus>().SetearVirus(splinesOleadas[GameManagerOleadas.instance.nivel].splines[Random.Range(0, splinesOleadas[GameManagerOleadas.instance.nivel].splines.Length)]);
            virusSpawneados.Add(virus);
            */

            GameManagerOleadas.instance.Spawnear(splinesOleadas[GameManagerOleadas.instance.nivel].SplineRandom);

        nextTimeSpawn = Time.time + tiempoEntreSpawn;
    }

    private void Update()
    {
        if (desactivar) return;


        if (Time.time > nextTimeSpawn)
        {
            SpawnearVirus();
        }
    }

    [ContextMenu("Spawn virus")]
    public void Iniciar()
    {
        desactivar = false;
        nextTimeSpawn = Time.time + tiempoEntreSpawn;
    }

    public void MostrarMensaje(int index)
    {
        mensajes[index].SetActive(true);
        animCamara.SetTrigger("cambiar");
        spawnFreq *= 1.2f;
        CalcularFrecuenciaSpawn();


    }

    public void PrimeraRonda()
    {
        mensajes[0].SetActive(true);
    }



}
