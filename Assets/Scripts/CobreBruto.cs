using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Collections;
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
    int startHp;

    private void Awake()
    {
        startScale = transform.localScale;
        startHp = hp;
        transform.localScale = Vector3.zero;
        
    }
    private void OnEnable()
    {
        StartCoroutine(Iniciar());
    }

    IEnumerator Iniciar()
    {
        yield return new WaitForSeconds(3);
        transform.DOScale(startScale.x, 1);
    }


    public void TapAction(Vector3 _point)
    {
        if (hp < 1) return;
        hp--;
        SoundManager.instance.TapearCobre();
        transform.DOShakeRotation(duracionScale, Vector3.one * fuerzaScale);
        transform.DOScale(startScale * 1.1f, .1f).OnComplete(() =>
        transform.DOScale(startScale, .1f)
        );


        if(hp < 1)
        {
            transform.DORotate(Vector3.zero, 1).SetEase(Ease.InOutSine);
            if(!sePuedeProcesar)
            {
                SpawnCobre.instance.Spawnear(transform.position, startScale, correaManager, transform.parent);
                transform.DOMove(correaManager.startPosCorreaCobre.position, 1).SetEase(Ease.InOutSine).OnComplete(() =>
                moverEnCorrea = true
                );
            }
            else
            {
                SoundManager.instance.DestruirCobre();
                transform.DOKill();
                GetComponentInParent<ProcesarCobre>().Procesar(transform.position);
                //Destroy(gameObject);
                gameObject.SetActive(false);
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



    private void OnDisable()
    {
        hp = startHp;
        sePuedeProcesar = false;
        moverEnCorrea = false;
        transform.localScale = Vector3.zero;
    }
}
