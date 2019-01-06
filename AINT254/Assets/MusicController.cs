using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{

    private IEnumerator FadeOut()
    {
        yield return gameObject.GetComponent<AudioSource>().FadeOutSoundToValue(0.2f, 0f, null);
    }

    private IEnumerator FadeIn()
    {
        yield return gameObject.GetComponent<AudioSource>().FadeInSoundToValue(0.5f, 1f, null);
    }

    private void Start()
    {
        StartCoroutine("FadeIn");
    }

    public void ButtonPressFadeOut()
    {
        StartCoroutine("FadeOut");
    }
}
