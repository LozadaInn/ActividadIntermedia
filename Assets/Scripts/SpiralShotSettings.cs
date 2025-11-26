using UnityEngine;

[CreateAssetMenu(menuName = "BulletHell System/Spiral Shot Settings")]
public class SpiralShotSettings : ScriptableObject
{
    public float BulletSpeed = 10f;
    public float AngleStep = 10f;   // cuánto avanza la espiral en cada disparo
    public float Cooldown = 0.05f;  // tiempo entre balas
    public int TotalShots = 200;    // tamaño total de la espiral
}
