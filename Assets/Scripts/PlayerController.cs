using Assets.Scripts.Business;
using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityExtensions;

public class PlayerController : MonoBehaviour
{
    public Weapon weapon;

    // Player Stats
    public float velocity, speedDecay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }


    /// <summary>
    /// Asks the weapon to shoot
    /// </summary>
    /// <param name="isFirstClick">True if the click that provoked that shot was a first click, or a maintained click</param>
    public void Shoot(bool isFirstClick)
    {
        weapon.Shoot(isFirstClick);
    }




}
