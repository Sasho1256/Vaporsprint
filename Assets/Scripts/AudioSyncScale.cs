using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//implements the AudioSyncer for the Scale of GameObjects
public class AudioSyncScale : AudioSyncer
{
    public Vector3 beatScale;
    public Vector3 restScale;

    //scales the current gameObject to the "target" scale over a certain time period
    private IEnumerator MoveToScale(Vector3 _target)
    {
        Vector3 _curr = transform.localScale;
        Vector3 _initial = _curr;
        float _timer = 0;

        while (_curr != _target)
        {
            _curr = Vector3.Lerp(_initial, _target, _timer / timeToBeat);
            _timer += (float)AudioSettings.dspTime;

            transform.localScale = _curr;

            yield return null;
        }

        m_isBeat = false;
    }

    //overrides OnUpdate() from AudioSyncer
    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat) return;

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
    }

    //overrides OnBeat() from  AudioSyncer and calls MoveToScale as a Coroutine
    public override void OnBeat()
    {
        base.OnBeat();

        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }
}
