using UnityEngine;
using System.Collections;

public class SpiralShotWeapon : MonoBehaviour
{
    [SerializeField] private SpiralShotSettings _settings;

    public System.Action OnFinished;

    private bool _shooting = false;
    private float _currentAngle = 0f;

    public void StartShooting()
    {
        if (!_shooting)
            StartCoroutine(DoSpiral());
    }

    private IEnumerator DoSpiral()
    {
        _shooting = true;

        Vector2 origin = transform.position;
        Vector2 aimDirection = transform.up;

        for (int i = 0; i < _settings.TotalShots; i++)
        {
            ShotAttack.SpiralShot(origin, aimDirection, _settings, ref _currentAngle);
            yield return new WaitForSeconds(_settings.Cooldown);

            origin = transform.position;
        }

        _shooting = false;
        OnFinished?.Invoke();
    }
}
