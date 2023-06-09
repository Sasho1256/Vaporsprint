using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias;
    public float timeStep;
    public float timeToBeat;
    public float restSmoothTime;

    private float m_previousAudioValue;
    private float m_audioValue;
    private float m_timer;

    protected bool m_isBeat;

    public virtual void OnUpdate()
    {
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioSpectrum.spectrumValue;

        //if the change from one beat to the next one is above a certain bias it triggers OnBeat()
        if(m_previousAudioValue > bias && m_audioValue <= bias)
        {
            if(m_timer > timeStep)
            {
                OnBeat();
            }
        }

        if (m_previousAudioValue <= bias && m_audioValue > bias)
        {
            if (m_timer > timeStep)
            {
                OnBeat();
            }
        }

        m_timer += (float)AudioSettings.dspTime;
    }

    //sets m_isBeat to true, so that classes inheriting from this one can use this to determine a beat
    public virtual void OnBeat()
    {
        m_timer = 0;
        m_isBeat = true;
    }

    // Update is called once per frame
    void Update()
    {
        OnUpdate();
    }
}
