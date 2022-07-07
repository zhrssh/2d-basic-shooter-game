using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject deathUI;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        deathUI.SetActive(false);
        interval = 0.01f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            guns[0].SetActive(true);
            guns[1].SetActive(false);
            guns[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            guns[0].SetActive(false);
            guns[1].SetActive(true);
            guns[2].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            guns[0].SetActive(false);
            guns[1].SetActive(false);
            guns[2].SetActive(true);
        }
    }

    private void OnDestroy()
    {
        deathUI.SetActive(true);
    }
}
