using UnityEngine;
using TMPro;
public class ProcesarCobre : MonoBehaviour
{
    public GameObject hitFx;
    public Transform entradaFrasco;
    public Transform[] posicionesFrasco;
    public GameObject cobreProcesado;
    int cantidadCobreProcesado;
    public float velocidadEntradaFrasco, velocidadCaida;
    public Puntaje puntaje;
    public Score score;

    private void Awake()
    {
        score.puntaje = 0;
    }

    public void Procesar(Vector3 pos)
    {
        Instantiate(hitFx, pos, Quaternion.identity);
        print("procesar");
        GameObject cobre = (GameObject)Instantiate(cobreProcesado, pos, Quaternion.identity);
        cobre.GetComponent<CobreLab>().CaerAlFrasco(entradaFrasco.position, posicionesFrasco[cantidadCobreProcesado % posicionesFrasco.Length].position, velocidadEntradaFrasco, velocidadCaida);
        cantidadCobreProcesado++;
        score.puntaje = cantidadCobreProcesado;
        puntaje.ActualizarPuntaje(cantidadCobreProcesado);
    }
}
