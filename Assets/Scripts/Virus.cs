using DG.Tweening;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Splines;

public class Virus : MonoBehaviour, ITapeable
{
    public GameObject hitFX, deadFX;
    public int hp;
    public float fuerzaScale, duracionScale;
    Vector3 startScale;
    public Transform spawnPointExplosion;
    Vector3 explosionPos;
    bool murio;

    public SplineAnimate splineAnimate;
    public float speed;
    int startHp;
    float startSpeed;


    private void Awake()
    {
        startScale = transform.localScale;
        startHp = hp;
        startSpeed = splineAnimate.MaxSpeed;
    }
    public void HitFX(Vector3 _point)
    {
        if (hp > 0)
        {
            // Instantiate(hitFX, _point, Quaternion.identity);
            SoundManager.instance.GolpearVirus();
        }
        else
        {
            SoundManager.instance.MatarVirus();
            splineAnimate.enabled = false;
            //Instantiate(hitFX, _point, Quaternion.identity);
            transform.DOKill();
            explosionPos = spawnPointExplosion.position;
            transform.DOScale(Vector3.zero, 0.2f).OnComplete(Murio);

        }
    }

    public void Murio()
    {
        explosionPos = spawnPointExplosion.position;
        Quaternion rot = Quaternion.Euler(new Vector3(-90, 0, 0));
        PoolFX.instance.SpawnHit(transform.position, Quaternion.identity);
        //Instantiate(hitFX, transform.position, Quaternion.identity);
        PoolFX.instance.SpawnExplosion(explosionPos, rot);
        //Instantiate(deadFX, explosionPos, rot);
        gameObject.SetActive(false);
    }
    public void TapAction(Vector3 _point)
    {
        PoolFX.instance.SpawnHit(_point, Quaternion.identity);
        //Instantiate(hitFX, _point, Quaternion.identity);
        if (hp < 1) return;
        hp--;

        transform.DOShakeRotation(duracionScale, Vector3.one * fuerzaScale);
        transform.DOScale(startScale * 1.1f, .1f).OnComplete(() =>
        transform.DOScale(startScale, .1f)
        );
    }

    public void SetearVirus(SplineContainer _spline, float _speed)
    {
        splineAnimate.enabled = true;
        splineAnimate.MaxSpeed = startSpeed + _speed;
        splineAnimate.Container = _spline;
        splineAnimate.Play();
    }

    public void Explotar()
    {
        transform.DOKill();
        explosionPos = spawnPointExplosion.position;
        transform.DOScale(Vector3.zero, 0.2f).OnComplete(Murio);
    }

    private void OnDisable()
    {
        transform.DOKill();
        transform.localScale = startScale;
        hp = startHp;
        murio = false;
        transform.position = Vector3.zero;
        splineAnimate.ElapsedTime = 0;

    }

}
