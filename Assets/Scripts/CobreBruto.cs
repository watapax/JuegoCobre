using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class CobreBruto : MonoBehaviour, ITapeable
{
    public CorreaManager correaManager;
    public UnityEvent onExtraer;
    public int hp;
    public float duracionScale, fuerzaScale;
    public GameObject hitFX;
    Vector3 startScale;
    bool moverEnCorrea;
    public bool sePuedeProcesar;

    private void Awake()
    {
        startScale = transform.localScale;
    }
    public void TapAction(Vector3 _point)
    {
        if (hp < 1) return;
        hp--;

        transform.DOShakeRotation(duracionScale, Vector3.one * fuerzaScale);
        transform.DOScale(startScale * 1.1f, .1f).OnComplete(() =>
        transform.DOScale(startScale, .1f)
        );


        if(hp < 1)
        {
            transform.DORotate(Vector3.zero, 1).SetEase(Ease.InOutSine);
            if(!sePuedeProcesar)
            {
                transform.DOMove(correaManager.startPosCorreaCobre.position, 1).SetEase(Ease.InOutSine).OnComplete(() =>
                moverEnCorrea = true
                );
            }
            else
            {
                transform.DOKill();
                GetComponentInParent<ProcesarCobre>().Procesar(transform.position);
                Destroy(gameObject);
            }

        }
            //onExtraer?.Invoke();
    }

    public void HitFX(Vector3 _point)
    {
        if (hp < 1) return;
        Instantiate(hitFX, _point, Quaternion.identity);
    }

    private void Update()
    {
        if (!moverEnCorrea) return;

        transform.Translate(Vector3.right * correaManager.velocidadCorrea * Time.deltaTime);


    }
}
