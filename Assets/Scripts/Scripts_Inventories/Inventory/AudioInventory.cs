using UnityEngine;
using System.Collections;

public class AudioInventory : MonoBehaviour
{

    public AudioClip source;

    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioClip>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            source.LoadAudioData();
        }
    }
}
