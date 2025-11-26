using UnityEngine;

[CreateAssetMenu(menuName = "BulletHell System/Radial Shot Pattern")]

public class RadialShotPattern : ScriptableObject
{
    public int Repetitions;
    public RadialShotSettings[] PatternSettings;

    [Tooltip("Tiempo (seg) a esperar antes de iniciar el patrón")]
    public float StartWait = 0f;

    [Tooltip("Tiempo (seg) a esperar después de terminar el patrón")]
    public float EndWait = 0f;
}
