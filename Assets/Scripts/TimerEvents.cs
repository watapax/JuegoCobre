using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Eventos
{
    public float timer;
    public UnityEvent evento;
    bool seGatillo;
    public void Gatillar()
    {
        if (seGatillo) return;
        evento?.Invoke();
        seGatillo = true;
    }
    
}
public class TimerEvents : MonoBehaviour
{
    public Eventos[] eventos;
    float t;

    private void Update()
    {
        t += Time.deltaTime;

        for (int i = 0; i < eventos.Length; i++)
        {
            if(t > eventos[i].timer)
            {
                eventos[i].Gatillar();
            }
        }
    }
}
