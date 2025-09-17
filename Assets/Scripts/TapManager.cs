using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class TapManager : MonoBehaviour
{
    public string name;
    public Camera camera;
    public Vector2 coordenadasCamara;
    public int index;
    public int score;
    public TextMeshProUGUI scoreTxt;
    public Score _score;
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
                if(hitInfo.transform.GetComponent<Virus>())
                {
                   if(hitInfo.transform.GetComponent<Virus>().hp < 1)
                    {
                        score++;
                        _score.puntaje += 1;
                        scoreTxt.text = score.ToString();
                       
                    }
                }

            }

        }
    }

    bool TapOnThisCamera(Vector2 _tapPos)
    {
        return false;
    }


}
