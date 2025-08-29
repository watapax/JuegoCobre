using UnityEngine;

public class Correa : MonoBehaviour
{
    public float xReturn;
    public float velocidad;
    Vector3 startPos;
    public bool avanza;
    private void Awake()
    {
        startPos = transform.localPosition;
    }
    private void Update()
    {
        transform.Translate(Vector3.right * velocidad *  Time.deltaTime);

        if(avanza)
        {
            if (transform.localPosition.x >= xReturn)
            {
                transform.localPosition = startPos;
            }
        }
        else
        {
            if (transform.localPosition.x <= xReturn)
            {
                transform.localPosition = startPos;
            }
        }



    }
}
