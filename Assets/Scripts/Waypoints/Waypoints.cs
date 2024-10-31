using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Waypoint : MonoBehaviour
{

    FadeInOut fade;
    public string sceneToLoad;

    private void Start()
    {
        fade = FindObjectOfType<FadeInOut>();
    }

    public IEnumerator ChangeScene()
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }
}
