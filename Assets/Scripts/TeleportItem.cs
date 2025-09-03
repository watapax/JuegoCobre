using UnityEngine;

public class TeleportItem : MonoBehaviour
{
    public bool killItem;
    public Transform spawnPos;
    public CorreaManager correaManager;
    public Transform parentItem;
    public int nextHp;
    private void OnTriggerEnter(Collider other)
    {
        if(killItem)
        {
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
            return;
        }
        other.GetComponent<CobreBruto>().correaManager = correaManager;
        other.GetComponent<CobreBruto>().sePuedeProcesar = true;
        other.GetComponent<CobreBruto>().hp = nextHp;
        other.transform.position = spawnPos.position;
        other.transform.parent = parentItem;
    }


}
