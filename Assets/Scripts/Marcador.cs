using UnityEngine;
using DG.Tweening;
public class Marcador : MonoBehaviour
{
    Vector3 startScale;
    float scale;
    private void Start()
    {
        scale = Mathf.Abs(transform.localScale.x);
        startScale = transform.localScale;
        transform.localScale = Vector3.zero;
    }
    public void Agrandar()
    {
        transform.DOScale(scale, 1).SetEase(Ease.InOutSine);
    }

    public void Achicar()
    {
        transform.DOScale(0, 1).SetEase(Ease.InOutSine);
    }
}
