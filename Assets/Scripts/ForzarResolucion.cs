using UnityEngine;

public class ForzarResolucion : MonoBehaviour
{

    public int targetWidth;
    public int targetHeight;

    private void Awake()
    {
        Screen.SetResolution(targetWidth, targetHeight, true);
    }

}
