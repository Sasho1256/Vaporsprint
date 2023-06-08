using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float spectrumValue { get; private set; }

    private float[] m_audioSpectrum;
    // Start is called before the first frame update
    void Start()
    {
        m_audioSpectrum = new float[128];
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(m_audioSpectrum, 0, FFTWindow.Hamming); //gets the audiospectrum data from all currently playing sounds

        if(m_audioSpectrum != null && m_audioSpectrum.Length > 0)
        {
            spectrumValue = m_audioSpectrum[0] * 200; //scales it up, since it would be too small to recognize otherwise
        }
    }

}
