using UnityEngine;
using DG.Tweening;
using System.Collections;
public class Edificio : MonoBehaviour
{
    int hp;
    public Renderer r;
    public Color damageColor;
    float tDamage = 0.1f;
    float tRecover = 0.2f;
    Material[] materiales;
    Color[] coloresOriginales;
    private void Awake()
    {
        materiales = new Material[r.materials.Length];
        coloresOriginales = new Color[r.materials.Length];

        for (int i = 0; i < r.materials.Length; i++)
        {
            materiales[i] = r.materials[i];
            coloresOriginales[i] = materiales[i].color;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("virus"))
        {
            other.GetComponent<Virus>().Murio();
            Damage();
        }
    }

    [ContextMenu("Damage")]
    public void Damage()
    {
        hp--;

        transform.DOKill();
        transform.DOScale(0.9f, tDamage).OnComplete(() => transform.DOScale(1, tRecover));

        StopAllCoroutines();
        StartCoroutine(CambiarColor());



    }

    IEnumerator CambiarColor()
    {
        foreach (Material m in materiales)
        {
            m.DOColor(damageColor, tDamage * 2);
        }
        yield return new WaitForSeconds(tDamage * 2);
        int i = 0;
        foreach (Material m in materiales)
        {
            m.DOColor(coloresOriginales[i], tRecover);
            i++;
        }
    }
}
