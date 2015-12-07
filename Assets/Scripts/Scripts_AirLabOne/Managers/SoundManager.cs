using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{

    #region PublicVariable
    public AudioSource m_musicSource;
    public AudioSource m_efxSource;
    public static SoundManager instance = null;

    public float m_lowPitchRange = .95f;
    public float m_highPitchRange = 1.05f;

    #endregion

    #region MainMethod

    // Use this for initialization
    void Awake ()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
	}

    public void PlaySingle(AudioClip clip)
    {
        m_efxSource.clip = clip;
        m_efxSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(m_lowPitchRange, m_highPitchRange);

        m_efxSource.pitch = randomPitch;
        m_efxSource.clip = clips[randomIndex];
        m_efxSource.Play();
    }



    // Update is called once per frame
    void Update () {
	
	}
    #endregion

    #region PrivateAndProtected

    #endregion

    
}
