using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class FadeNegro : MonoBehaviour
{
    public Image fondo;
    public UnityEvent evento;

    private void Start()
    {
        fondo.DOColor(Color.clear, 4);
    }
    public void Fade()
    {
        fondo.DOColor(Color.black, 4).OnComplete(() => evento?.Invoke());
    }

}
