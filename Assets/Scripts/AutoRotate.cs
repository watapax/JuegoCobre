using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float velocidadRotacion;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.forward * velocidadRotacion * Time.deltaTime);
    }
}
