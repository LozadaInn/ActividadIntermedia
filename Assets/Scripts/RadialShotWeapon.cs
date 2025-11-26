using UnityEngine;
using System.Collections;

public class RadialShotWeapon : MonoBehaviour
{
    [SerializeField] private RadialShotPattern[] _shotPatterns;

    public System.Action OnFinished;

    private bool _onShotPattern = false;
    private int _currentPatternIndex = 0;

    public void StartShooting()
    {
        if (!_onShotPattern)
            StartCoroutine(ExecuteRadialShotPattern(_shotPatterns[_currentPatternIndex]));
    }

    private IEnumerator ExecuteRadialShotPattern(RadialShotPattern pattern)
    {
        _onShotPattern = true;
        int lap = 0;
        Vector2 aimDirection = transform.up;
        Vector2 center = transform.position;

        yield return new WaitForSeconds(pattern.StartWait);

        while (lap < pattern.Repetitions)
        {
            for (int i = 0; i < pattern.PatternSettings.Length; i++)
            {
                ShotAttack.RadialShot(center, aimDirection, pattern.PatternSettings[i]);
                yield return new WaitForSeconds(pattern.PatternSettings[i].CooldownAfterShot);
            }
            lap++;
        }

        yield return new WaitForSeconds(pattern.EndWait);

        _currentPatternIndex++;

        if (_currentPatternIndex < _shotPatterns.Length)
        {
            // Aún quedan patrones, dispara el siguiente
            _onShotPattern = false;
            StartShooting();
        }
        else
        {
            // Ya terminamos TODOS los radiales
            _currentPatternIndex = 0;
            _onShotPattern = false;
            OnFinished?.Invoke();
        }

    }
}
