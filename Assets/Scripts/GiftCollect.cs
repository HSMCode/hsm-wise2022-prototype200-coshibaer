using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftCollect : MonoBehaviour
{
    public AudioClip collectSFX;
    private AudioSource _audioSource;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = GameObject.Find("Canvas01").GetComponent<ScoreManager>();

        _audioSource = GetComponent<AudioSource>();
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreManager.score += 1f;
    
        Destroy(gameObject, 0.3f);

        _audioSource.PlayOneShot(collectSFX, 2f);
    }
}
