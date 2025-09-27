using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoCobre : MonoBehaviour
{

    public VideoPlayer player;

    IEnumerator Start()
    {
        player.Play();
        yield return new WaitForSeconds(5);
        
        while(player.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene(3);
    }




}
