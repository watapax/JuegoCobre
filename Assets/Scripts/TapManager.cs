using UnityEngine;

public class TapManager : MonoBehaviour
{
    public string name;
    public Camera camera;
    public Vector2 coordenadasCamara;
    private void Update()
    {
        for(int i = 0; i < Input.touchCount; i++)
        {
            Touch t = Input.GetTouch(i);

            if(t.phase == TouchPhase.Began)
            {
                OnTouchBegan(t);
            }
        }
    }


    void OnTouchBegan(Touch _t)
    {


        Ray ray = camera.ScreenPointToRay(_t.position);

        if(Physics.Raycast(ray, out RaycastHit hitInfo, 1000))
        {
            if(hitInfo.transform.GetComponent<ITapeable>()!= null)
            {
                hitInfo.transform.GetComponent<ITapeable>().TapAction(hitInfo.point);
                hitInfo.transform.GetComponent<ITapeable>().HitFX(hitInfo.point);
            }

        }
    }

    bool TapOnThisCamera(Vector2 _tapPos)
    {
        return false;
    }


}
