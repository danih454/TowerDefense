using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image image;
    public AnimationCurve fadeCurve;
    
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        Time.timeScale = 1f;
        //play alpha animation
        float t = 1f;
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float alpha = fadeCurve.Evaluate(t);
            image.color = new Color(0f,0f,0f,alpha);
            yield return 0; //skip to next frame
        }
    }

    IEnumerator FadeOut(string scene)
    {
        //play alpha animation
        float t = 0f;
        while(t < 1f)
        {
            t += Time.deltaTime;
            float alpha = fadeCurve.Evaluate(t);
            image.color = new Color(0f,0f,0f,alpha);
            yield return 0; //skip to next frame
        }
        SceneManager.LoadScene(scene);
    }
}
