using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioChecker : MonoBehaviour
{
    #region Public Variable

    #endregion

    #region Main Methode
    IEnumerator WaitUntilAudioIsDone()
    {
        while (m_audio.isPlaying)
        {
            yield return new WaitForSeconds(0);
        }

        Destroy(gameObject);
    }

    void Start()
    {
        m_audio = GetComponent<AudioSource>();
        StartCoroutine("WaitUntilAudioIsDone");
        //StopCoroutine("WaitUntilAudioIsDone");

        //StartCoroutine(WaitUntilAudioIsDone());
        //StopAllCoroutines();
    }
    #endregion

    #region Utils
    
    #endregion

    #region Private & Protected Variables
    AudioSource m_audio;
    #endregion
}
