using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetear : MonoBehaviour
{

    public float tiempo;
    bool resetear;
    float t = 0;
    public void IniciarReset()
    {
        resetear = true;
    }

    public void PararReset()
    {
        resetear = false;
        t = 0;
    }

    private void Update()
    {
        if(resetear)
        {
            t += Time.deltaTime;
            if(t > tiempo)
            {
                SceneManager.LoadScene(0);
            }

        }
    }
}
