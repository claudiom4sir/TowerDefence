using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneFader : MonoBehaviour {

    public Image img; // this is the black image
    public float timeForFadeIn = 2f;
    public float timeForFadeOut = 1f;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    //**USED INSTEAD OF LOADSCENE**
    public void FadeTo(string scene) // called when you need to change scene 
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn() // for to fade the color from  opaque to trasparent
    {
        float t = 1f;
        while(t > 0f)
        {
            img.color = new Color(0f, 0f, 0f, t);
            t = t - Time.deltaTime * timeForFadeIn;
            yield return 0;
        }
    }

    IEnumerator FadeOut(string scene) // for to fade the color from  trasparent from opaque
    {
        float t = 0f;
        while (t < 1f)
        {
            img.color = new Color(0f, 0f, 0f, t);
            t = t + Time.deltaTime * timeForFadeOut;
            yield return 0;
        }
        SceneManager.LoadScene(scene); // when image is totally opaque, load "scene" scene
    }

}
