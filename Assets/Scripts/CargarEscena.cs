using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarEscena : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cargar(int index)
    {
        SceneManager.LoadScene(index);
    }
}
