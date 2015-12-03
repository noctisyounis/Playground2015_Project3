using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioClips : MonoBehaviour {

    public List<AudioClip> m_audioClips;

    private static AudioSource m_audioSource;

    void Start()
    {
        m_audioSource = this.GetComponent<AudioSource>();
    }


    public void JouerSon(int id)
    {
        if (m_audioSource != null)
        {
            m_audioSource.PlayOneShot(m_audioClips[id], 1F);
        }
        else
        {
            Debug.Log("m_audioSource is null");
        }
        
    }
}
