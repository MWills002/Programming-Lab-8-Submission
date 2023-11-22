using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public enum EProjectileType
    {
        Silver,
        Gold,
        Diamond
    }

   
   




    public AudioSource src;

    public AudioClip shootsfx;


    [SerializeField] private float speed;
    private Vector3 _moveDir;

    [Header("Camera")]
    [SerializeField, Range(1, 20)] private float mouseSensX;
    [SerializeField, Range(1, 20)] private float mouseSensY;

    [SerializeField, Range(-90, 0)] private float MinViewAngle;
    [SerializeField, Range(0, 90)] private float MaxViewAngle;

    [SerializeField] private Transform followTarget;

    [Header("Shooting")]
    [SerializeField] private Rigidbody bulletPrefab;
    [SerializeField] private Rigidbody bulletPrefab2;
    [SerializeField] private Rigidbody bulletPrefab3;
    [SerializeField] private Rigidbody bulletPrefab4;
    [SerializeField] private float projectileForce;

    private bool gunFirst = true;
    private bool gunSecond = false;
    private bool gunThird = false;
    private bool gunFourth = false;

    private Vector2 currentAngle;

    [Header("Player UI")]
    [SerializeField] private Image healthBar;
    [SerializeField] private TextMeshProUGUI ammoLeft;

    [SerializeField] private float maxHealth;
    public int ammoCounter = 10;
    private float _health;

    //Ammo Text Ienumeration
    [field: SerializeField] public EProjectileType bulletType { get; private set; }







private float Health
    {
        get => _health;
        set
        {
            _health = value;
            healthBar.fillAmount = _health / maxHealth;
        }
    }





    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(this);
        InputManager.GameMode();

        Health = maxHealth;

    

    }

   

    // Update is called once per frame
    void Update()
    {
        transform.position += (speed * Time.deltaTime * _moveDir);

        Health -= Time.deltaTime * 4;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gunFirst = true;
            gunSecond = false;
            gunThird = false;
            gunFourth = false;

            Debug.Log("Regular Gun Equiped");

          

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gunFirst = false;
            gunSecond = true;
            gunThird = false;
            gunFourth = false;

            Debug.Log("Cube Gun Equiped");

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gunFirst = false;
            gunSecond = false;
            gunThird = true;
            gunFourth = false;

            Debug.Log("Tree Launcher Equiped");

        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gunFirst = false;
            gunSecond = false;
            gunThird = false;
            gunFourth = true;

            Debug.Log("Domain Expansion Default Sphere Equiped");

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            bulletType = EProjectileType.Silver;
            Debug.Log("Silver Bullets");

        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            bulletType = EProjectileType.Gold;
            Debug.Log("Gold Bullets");

        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            bulletType = EProjectileType.Diamond;
            Debug.Log("Diamond Bullets");

        }




    }

    public void SetMovementDirection(Vector3 newDirection)
    {
        _moveDir = newDirection;
    }

    public void SetLookRotation(Vector2 readValue)
    {
        currentAngle.x += readValue.x * Time.deltaTime * mouseSensX;
        currentAngle.y += readValue.y * Time.deltaTime * mouseSensY;

        currentAngle.y = Mathf.Clamp(currentAngle.y, MinViewAngle, MaxViewAngle);

        transform.rotation = Quaternion.AngleAxis(currentAngle.x, Vector3.up);
        followTarget.localRotation = Quaternion.AngleAxis(currentAngle.y, Vector3.right);
    }

    public void Shoot()
    {

        if(bulletType == EProjectileType.Silver)
        {
            //Debug.Log("Silver Bullets");
            gameObject.GetComponent<Renderer>().material.color = Color.cyan;
        }

        if (bulletType == EProjectileType.Gold)
        {
            //Debug.Log("Silver Bullets");
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }

        if (bulletType == EProjectileType.Diamond)
        {
            //Debug.Log("Silver Bullets");
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }


        if (ammoCounter > 0 && gunFirst == true)
        {

            Rigidbody currentProjectile = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);
            Destroy(currentProjectile.gameObject, 4);
            ammoCounter--;
            ammoLeft.text = ammoCounter.ToString();

            src.clip = shootsfx;
            src.Play();

   

        }

        if (ammoCounter > 0 && gunSecond == true)
        {

            Rigidbody currentProjectile = Instantiate(bulletPrefab2, transform.position, Quaternion.identity);
            currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);
            Destroy(currentProjectile.gameObject, 4);
            ammoCounter--;
            ammoLeft.text = ammoCounter.ToString();

            src.clip = shootsfx;
            src.Play();

        }

        if (ammoCounter > 0 && gunThird == true)
        {

            Rigidbody currentProjectile = Instantiate(bulletPrefab3, transform.position, Quaternion.identity);
            currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);
            Destroy(currentProjectile.gameObject, 4);
            ammoCounter--;
            ammoLeft.text = ammoCounter.ToString();

            src.clip = shootsfx;
            src.Play();

        }

        if (ammoCounter > 0 && gunFourth == true)
        {

            Rigidbody currentProjectile = Instantiate(bulletPrefab4, transform.position, Quaternion.identity);
            currentProjectile.AddForce(followTarget.forward * projectileForce, ForceMode.Impulse);
            Destroy(currentProjectile.gameObject, 4);
            ammoCounter--;
            ammoLeft.text = ammoCounter.ToString();

            src.clip = shootsfx;
            src.Play();

        }

        if (ammoCounter == 0)
        {
            Debug.Log("Out of Ammo");
        }
       
    }

    public void Reload()
    {
        Debug.Log("Reloaded +10");
        if (ammoCounter == 0)
        {
            ammoCounter = ammoCounter + 10;
        }
    }



 


}
