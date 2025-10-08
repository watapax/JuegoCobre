using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
public class VideoCobre : MonoBehaviour
{

    public VideoPlayer player;

    IEnumerator Start()
    {
        player.Prepare();
        while (!player.isPrepared)
        {
            Debug.Log("waiting");
            yield return null;
        }
        Debug.Log("VideoReady");
        player.Play();
        yield return new WaitForSeconds(1);
        
        while(player.isPlaying)
        {
            yield return null;
        }
        Debug.Log("VideoEnded");
        SceneManager.LoadScene(3);
    }




}
