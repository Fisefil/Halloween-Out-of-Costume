using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaxButton : MonoBehaviour
{
    private AudioSource SaxTime;
    public void Sax()
    {
        SaxTime = GetComponent<AudioSource>();
        SaxTime.Play();
    }
}
