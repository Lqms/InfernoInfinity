using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    [SerializeField] private Image _timer;
    [SerializeField] private QTETimer _qteTimer;

    private Coroutine _coroutine;

    private void OnEnable()
    {
        _qteTimer.TimerReseted += OnTimerReseted;
    }

    private void OnDisable()
    {
        _qteTimer.TimerReseted -= OnTimerReseted;
    }

    private void OnTimerReseted(float time)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(CountingDown(time));
    }

    private IEnumerator CountingDown(float time)
    {
        _timer.fillAmount = 1;

        while (_timer.fillAmount > 0)
        {
            _timer.fillAmount -= Time.deltaTime / time;
            yield return null;
        }
    }
}
