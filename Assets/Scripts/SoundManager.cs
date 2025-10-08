using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
public class SoundManager : MonoBehaviour
{
    public UnityEvent onEndIntro, onEndFinal;
    public AudioClip locucionIntro, locucionFinal;
    public static SoundManager instance;
    public UnityEvent onLevelFinish;
    public AudioSource bgmSource, sfxSource;

    public AudioClip bgm, golpearVirus, matarVirus, golpeaEdificio, destruirCobre;
    public AudioClip[] tapeaCobre;
    public bool isLevel1;

    private void Awake()
    {
        instance = this;
    }



    private void Start()
    {
        LocucionIntro();
        if(!isLevel1)
            IniciarMusicaFondo();

    }
    public void IniciarMusicaFondo()
    {
        bgmSource.clip = bgm;
        bgmSource.Play();
        if(isLevel1)
            StartCoroutine(FinishSong());
    }

    IEnumerator FinishSong()
    {
        float lenght = bgmSource.clip.length;

        yield return new WaitForSeconds(lenght + 4);
        onLevelFinish?.Invoke();
        DOTween.KillAll();
    }

    public void BajarVolumenMusica()
    {
        bgmSource.DOFade(0, 4);
    }



    IEnumerator SubirVolumenConDelay(float _delay, UnityEvent _event)
    {
        yield return new WaitForSeconds(_delay);
        bgmSource.DOFade(1, 3f).OnComplete(() => _event?.Invoke());

    }

    public void LocucionIntro()
    {
        float l = locucionIntro.length;
        bgmSource.DOFade(0.3f, 3f).OnComplete(() => sfxSource.PlayOneShot(locucionIntro));
        StartCoroutine(SubirVolumenConDelay(l, onEndIntro));
    }

    public void LocucionFinal()
    {

        bgmSource.DOFade(0, 4).OnComplete(()=> sfxSource.PlayOneShot(locucionFinal));
        StartCoroutine(Final(locucionFinal.length));
    }

    IEnumerator Final(float _t)
    {
        yield return new WaitForSeconds(_t + 4);
        onLevelFinish?.Invoke();
        DOTween.KillAll();
    }

    public void GolpearVirus()
    {
        sfxSource.PlayOneShot(golpearVirus);
    }

    public void MatarVirus()
    {
        sfxSource.PlayOneShot(matarVirus);
    }

    public void GolpeaEdificio()
    {
        sfxSource.PlayOneShot(golpeaEdificio);
    }

    public void TapearCobre()
    {
        sfxSource.PlayOneShot(tapeaCobre[Random.Range(0, tapeaCobre.Length)]);
    }

    public void DestruirCobre()
    {
        sfxSource.PlayOneShot(destruirCobre);
    }

}
