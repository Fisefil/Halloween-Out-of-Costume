using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaxButton : MonoBehaviour
{
    public AudioSource SaxTime;
    public void Sax()
    {
        SaxTime = GetComponent<AudioSource>();
        SaxTime.Play();
    }
}
