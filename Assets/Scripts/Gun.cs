using System.Collections;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField] protected int capacity;
    [SerializeField] protected float fireRate;
    [SerializeField] protected float reloadTime;
    [SerializeField] protected GameObject prefab;

    [SerializeField] protected Transform muzzle;

    [SerializeField] private TextMeshProUGUI text;

    private int ammo;

    private bool isReloading;
    private bool isFiring;

    // Start is called before the first frame update
    void Start()
    {
        // Always start with full ammo;
        text.enabled = false;
        ammo = capacity;
    }

    // Update is called once per frame
    void Update()
    {
        // Fires at specific fire rate and only if couroutine is not running
        if (Input.GetButton("Fire1") && ammo > 0 && !isFiring && !isReloading)
        {
            isFiring = true;
            StartCoroutine(Fire());
        }

        // Reloads the gun
        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            StartCoroutine(Reload());
        }

        // Tells if the gun has no ammo
        if (ammo <= 0)
        {
            text.enabled = true;
        }
        else
        {
            text.enabled = false;
        }
    }

    private IEnumerator Reload()
    {
        Debug.Log("Reloading!");
        ammo = capacity;
        yield return new WaitForSeconds(reloadTime);

        Debug.Log("Ready to Fire!");
        isReloading = false;
    }

    private IEnumerator Fire()
    {
        // Spawns the bullet
        Instantiate(prefab, muzzle.transform.position, muzzle.transform.rotation);
        
        // Specifies the fire rate
        yield return new WaitForSeconds(1f / fireRate);
        
        // Substracts the ammo from the mag
        if (ammo > 0) ammo = ammo - 1;
        isFiring = false;
    }
}
