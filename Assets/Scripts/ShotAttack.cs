using UnityEngine;

public static class ShotAttack
{
    public static void SimpleShot(Vector2 origin, Vector2 velocity)
    {
        Bullet bullet = BulletPool.Instance.RequestBullet();
        bullet.transform.position = origin;
        bullet.velocity = velocity;
    }

    public static void RadialShot (Vector2 origin, Vector2 aimDirection, RadialShotSettings settings)
    {
        float angleBetweenBullets = 360f / settings.NumberOfBullets;

        if (settings.AngleOffset != 0f || settings.PhaseOffset != 0f)
        {
            aimDirection = aimDirection.Rotate(settings.AngleOffset + (settings.PhaseOffset * angleBetweenBullets));
        }

        for (int i = 0; i < settings.NumberOfBullets; i++)
        {
            float bulletDirectionAngle = i * angleBetweenBullets;

            Vector2 bulletDirection = aimDirection.Rotate(bulletDirectionAngle);
            SimpleShot(origin, bulletDirection * settings.BulletSpeed);
        }
    }

    public static void SpiralShot(Vector2 origin, Vector2 aimDirection, SpiralShotSettings settings, ref float currentAngle)
    {
        // Calcula dirección rotando aimDirection por el ángulo acumulado
        Vector2 direction = aimDirection.Rotate(currentAngle);

        // Disparo
        SimpleShot(origin, direction * settings.BulletSpeed);

        // Incrementa el ángulo para el siguiente disparo
        currentAngle += settings.AngleStep;

        if (currentAngle >= 360f)
            currentAngle -= 360f;
    }

}
