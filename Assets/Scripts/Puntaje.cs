using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class Puntaje : MonoBehaviour
{
    public RectTransform rectPuntaje;
    public TextMeshProUGUI txtPuntaje;

    public void ActualizarPuntaje(int puntaje)
    {
        txtPuntaje.text = puntaje.ToString();
        rectPuntaje.DOScale(1.2f, 0.2f).SetEase(Ease.InSine).OnComplete(() =>
        rectPuntaje.DOScale(1,0.2f).SetEase(Ease.OutSine
        ));
    }
}
