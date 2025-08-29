using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Splines;
using UnityEngine.UI;
[System.Serializable]


public class GameManagerOleadas : MonoBehaviour
{
    public static GameManagerOleadas instance;
    public float duracionOleada;
    public float tiempoActual;
    public int nivel;
    public JuegoCiudad juegoA, juegoB;
    bool iniciar;

    public GameObject virusPrefab;

    public List<GameObject> virusList = new List<GameObject>();
    public GameObject[] fadeOuts;

    public Image[] barrasTiempo;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < fadeOuts.Length; i++)
        {
            fadeOuts[i].SetActive(true);
        }
        Invoke("PrimeraRonda", 3.5f);
    }


    public void IniciarJuego()
    {
        iniciar = true;

        if (juegoA != null)
            juegoA.Iniciar();

        if (juegoB != null)
            juegoB.Iniciar();
    }

    private void Update()
    {
        if (!iniciar) return;

        tiempoActual += Time.deltaTime;


        if (tiempoActual > duracionOleada)
        {
            TerminoOleada();
        }

        float p = tiempoActual / duracionOleada;

        for (int i = 0; i < barrasTiempo.Length; i++)
        {
            barrasTiempo[i].fillAmount = 1 - p;
        }
    }

    public void TerminoOleada()
    {

        Explotar();

        iniciar = false;
        nivel++;
        tiempoActual = 0;
        if (juegoA != null)
        {
            juegoA.desactivar = true;
            juegoA.MostrarMensaje(nivel);
        }

        if (juegoB != null)
        {
            juegoB.desactivar = true;
            juegoB.MostrarMensaje(nivel);
        }

        if (nivel < 3)
            Invoke("ReanudarJuego", 3.5f);
    }

    void Explotar()
    {
        for (int i = 0; i < virusList.Count; i++)
        {
            virusList[i].GetComponent<Virus>().Explotar();
        }
    }

    void ReanudarJuego()
    {
        IniciarJuego();
    }

    void PrimeraRonda()
    {
        if (juegoA != null)
            juegoA.PrimeraRonda();

        if (juegoB != null)
            juegoB.PrimeraRonda();

        Invoke("ReanudarJuego", 3.5f);
    }


    public void Spawnear(SplineContainer _spline)
    {
        bool hayDisponibles = false;

        for (int i = 0; i < virusList.Count; i++)
        {
            if (!virusList[i].activeInHierarchy)
            {

                virusList[i].SetActive(true);
                virusList[i].GetComponent<Virus>().SetearVirus(_spline, nivel);
                hayDisponibles = true;
                break;
            }
        }

        if (!hayDisponibles)
        {
            GameObject _virus = Instantiate(virusPrefab);
            _virus.GetComponent<Virus>().SetearVirus(_spline, nivel);
            virusList.Add(_virus);
        }
    }


}
