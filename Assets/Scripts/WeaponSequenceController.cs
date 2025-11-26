using UnityEngine;
using System.Collections;

public class WeaponSequenceController : MonoBehaviour
{
    [SerializeField] private RadialShotWeapon radialWeapon;
    [SerializeField] private SpiralShotWeapon spiralWeapon;

    private void Start()
    {
        StartCoroutine(SequenceRoutine());
    }

    private IEnumerator SequenceRoutine()
    {
        // 1. Ejecutar radiales
        bool radialDone = false;
        radialWeapon.OnFinished = () => radialDone = true;
        radialWeapon.StartShooting();  // hacer público algún Start

        yield return new WaitUntil(() => radialDone);

        // 2. Ejecutar espiral
        bool spiralDone = false;
        spiralWeapon.OnFinished = () => spiralDone = true;
        spiralWeapon.StartShooting();  // igual y hacer un método público

        yield return new WaitUntil(() => spiralDone);

        // 3. repetir en bucle
        StartCoroutine(SequenceRoutine());
    }
}
