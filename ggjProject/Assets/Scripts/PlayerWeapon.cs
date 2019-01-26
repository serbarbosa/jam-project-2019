using UnityEngine;

[System.Serializable]
public class PlayerWeapon{

    public string name = "cubed gun";

    public float range = 20f;
    public float cooldown = 3f;

    public float nextTimeToFire = 0f;

    public ParticleSystem muzzleFlash;

}
