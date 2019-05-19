using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandom : MonoBehaviour
{
    private AudioSource audioSource;
    public List<AudioClip> audioList;
    private Random random;
    // Start is called before the first frame update
    void Start()
    {
        random = new Random();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandom() {
        audioSource.PlayOneShot(audioList[Random.Range(0,audioList.Count-1)]);
    }
}
