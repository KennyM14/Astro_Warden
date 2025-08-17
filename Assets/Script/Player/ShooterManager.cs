using UnityEngine;
using System.Collections.Generic;


public class ShooterManager : MonoBehaviour
{
    public List<Shooter> shooters; 
    public float fireRate = 0.3f;
    private float fireCooldown = 0f;
    public bool autoFire = false;

    void Update()
    {
        if (!autoFire) return;
        fireCooldown -= Time.deltaTime;

        if (fireCooldown <= 0f)
        {
            ShootAll();
            fireCooldown = fireRate;
        }
    }

    public void ShootAll()
    {
        foreach (Shooter shooter in shooters)
        {
            shooter.Shoot();
        }
    }

    bool ShouldFire()
    {
        // Para el jugador: siempre dispara
        // Para enemigos: solo si detectan al jugador
        return true; // Reemplaza con lógica personalizada
    }

}
