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

    public void Procesar(Vector3 pos)
    {
        Instantiate(hitFx, pos, Quaternion.identity);
        print("procesar");
        GameObject cobre = (GameObject)Instantiate(cobreProcesado, pos, Quaternion.identity);
        cobre.GetComponent<CobreLab>().CaerAlFrasco(entradaFrasco.position, posicionesFrasco[cantidadCobreProcesado % posicionesFrasco.Length].position, velocidadEntradaFrasco, velocidadCaida);
        cantidadCobreProcesado++;
        puntaje.ActualizarPuntaje(cantidadCobreProcesado);
    }
}
