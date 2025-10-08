using UnityEngine;

public class Destruir : MonoBehaviour
{
    public GameObject todo;
    public void DestruirTodo()
    {
        Destroy(todo);
    }
}
