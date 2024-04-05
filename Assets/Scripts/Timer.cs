using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private int _step;
    [SerializeField] private float _delay;

    private int _currentCount = 0;
    private bool _isActive = false;
    private WaitForSeconds _wait;

    private void Start()
    {
        _delay = 0.5f;
        _step = 1;
        _text.text = _currentCount.ToString("");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isActive)
            {
                _isActive = false;
                StartCoroutine(IncreaseTime(_step));
            }
            else
            {
                _isActive = true;
                _wait = new WaitForSeconds(_delay);
                StartCoroutine(IncreaseTime(_step));
            }
        }
    }

    private IEnumerator IncreaseTime(int step)
    {
        while (_isActive)
        {
            _currentCount += step;
            _text.text = _currentCount.ToString("");
            yield return _wait;
        }
    }
}
