using UnityEngine;

public class ForzarResolucion : MonoBehaviour
{

    public int targetWidth;
    public int targetHeight;

    private void Awake()
    {
        Screen.SetResolution(1920, 1080,true);
    }

}
