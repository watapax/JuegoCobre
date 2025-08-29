using UnityEngine;
using DG.Tweening;
public class CobreLab : MonoBehaviour
{
    public Transform[] posiciones, cobres;
    float[] r = new float[4];
    public float velocidad;
    public Transform parentPosiciones;
    Vector3 posFrasco;
    float  velocidadCaida;
    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            r[i] = Random.Range(0.03f, 0.06f);
        }
    }
    private void Update()
    {
        for (int i = 0; i < posiciones.Length; i++)
        {
            cobres[i].position = Vector3.Lerp(cobres[i].position, posiciones[i].position, r[i] + velocidad * Time.deltaTime);
        }
    }

    public void CaerAlFrasco(Vector3 _entradaFrasco, Vector3 _posicionFrasco, float _velocidadEntrada, float _velocidadCaida)
    {

        velocidadCaida = _velocidadCaida;
        posFrasco = _posicionFrasco;
        parentPosiciones.DORotate(RandomVector(), _velocidadEntrada).SetEase(Ease.InSine);
        parentPosiciones.DOMove(_entradaFrasco, _velocidadEntrada).SetEase(Ease.InSine).OnComplete(EntrarAlFrasco);
    }

    void EntrarAlFrasco()
    {
        parentPosiciones.DORotate(Vector3.zero, velocidadCaida).SetEase(Ease.OutSine);
        parentPosiciones.DOMove(posFrasco, velocidadCaida).SetEase(Ease.OutSine);
    }

    Vector3 RandomVector()
    {
        float x = Random.Range(0, 360);
        float y = Random.Range(0, 360);
        float z = Random.Range(0, 360);
        return new Vector3 (x, y, z);
    }
}
