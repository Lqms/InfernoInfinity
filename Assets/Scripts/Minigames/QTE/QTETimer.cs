using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QTETimer : MonoBehaviour
{
    [SerializeField] private QTEKey _qteKey;

    private Coroutine _coroutine;

    public event UnityAction<float> TimerReseted;
    public event UnityAction TimeOvered;

    public void SetNewTimer(float time)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        // time = 3; // random
        _qteKey.GenerateKey();
        TimerReseted?.Invoke(time);

        _coroutine = StartCoroutine(CountingDown(time));
    }

    private IEnumerator CountingDown(float time)
    {
        yield return new WaitForSeconds(time);
        TimeOvered?.Invoke();
        SetNewTimer(time);
    }
}