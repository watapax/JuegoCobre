using UnityEngine;
using DG.Tweening;
using System.Collections;
using UnityEngine.SceneManagement;

public class VideoCobre : MonoBehaviour
{
    public AudioClip locCobre;
    public AudioSource audioSource;
    private void Start()
    {
        StartCoroutine(PlayAndEvent());
    }

    IEnumerator PlayAndEvent()
    {
        float l = locCobre.length;
        audioSource.PlayOneShot(locCobre);
        yield return new WaitForSeconds(l);
        SceneManager.LoadScene(2);

    }
}
