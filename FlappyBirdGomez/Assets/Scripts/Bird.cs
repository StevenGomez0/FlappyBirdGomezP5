using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f;
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private AudioSource audio;

    public AudioClip death;
    public AudioClip flap;
    public AudioClip scored;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(new Vector2(0, upForce));
                anim.SetTrigger("Flap");
                PlaySound(flap);
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        PlaySound(death);

        GameControl.instance.BirdDied();
    }
    public void PlaySound(AudioClip clip)
    {
        audio.PlayOneShot(clip);
    }
}
