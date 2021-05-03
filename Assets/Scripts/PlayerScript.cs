using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private float Horizontal;
    private float Vertical;
    private Rigidbody2D RB;
    private bool Grounded;
    public Transform FeetPos;
    public float CheckRadius;
    public LayerMask WhatIsGrounded;
    private float JumpTimeCounter;
    public float JumpTime;
    private bool IsJumping;
    private int Jumps;

    public float PlayerDashSpeed;
    public float StartDashTime;
    private float DashTimeCounter;
    private Vector2 DirectionFromMouse;
    private bool Dashing;
    private float NumDash;
    private bool DashDirection;

    public GameObject BulletPrefab;
    private float LastShoot;
    public GameObject bullet;
    public bool BoomerEnEscena;
    public bool PasoVidaBoomer;
    public float tiempo;
    public float tiempoInmune;
    private bool MeDuele = true;
    private Animator Anim;
    public GameObject Crono;
    public int Vidas;
    public int MaxVidas = 5;
    public int MinVidas = 0;
    public bool DasheOk;
    public bool JumpOk;
    public GameObject PoderesDash;
    public GameObject PoderesJump;
    public GameObject PuertaMazmorra;
    private GameObject CF;
    //private SoundManager SM;
    //private GlitchEffect GE;
    
    // Start is called before the first frame update
    void Start()
    {
        BoomerEnEscena = false;
        RB = GetComponent<Rigidbody2D>();
        //Crono = GameObject.FindGameObjectWithTag("Reloj");

        //Crono = GetComponent<Reloj>();
        Dashing = false;
        DashTimeCounter = StartDashTime;
        Anim = GetComponent<Animator>();
        Vidas = 5;
        DasheOk = false;
        JumpOk = false;
    }

    // Update is called once per frame
    void Update()
    {
        //PoderesDash = GameObject.FindGameObjectWithTag("PoderDash");
        //PoderesJump = GameObject.FindGameObjectWithTag("PoderSalto");
        //PuertaMazmorra = GameObject.FindGameObjectWithTag("Mazmorra");
        //CF = GameObject.FindGameObjectWithTag("MainCamera");
        //SM = GameObject.FindGameObjectWithTag("BackMusik").GetComponent<SoundManager>();
        //GE = GameObject.FindGameObjectWithTag("Camera").GetComponent<GlitchEffect>();
        //CF = GetComponent<CameraFollow>();
        if (Vidas > MaxVidas)
        {
            Vidas = MaxVidas;
        }
        if (Vidas < MinVidas)
        {
            Vidas = MinVidas;
            //GE.colorIntensity = 1;
            //GE.intensity = 1;
            //GE.flipIntensity = 1;
        }
        if (PasoVidaBoomer == true)
        {
            BoomerEnEscena = false;
        }
        Grounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, WhatIsGrounded);
        if (Vidas > 0)
        {
            Grounded = Physics2D.OverlapCircle(FeetPos.position, CheckRadius, WhatIsGrounded);
            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.Space))
            {
                Jump();

            }
            if (Input.GetKey(KeyCode.JoystickButton1) && IsJumping == true || Input.GetKey(KeyCode.Space) && IsJumping == true)
            {
                if (JumpTimeCounter > 0)
                {
                    RB.velocity = new Vector2(RB.velocity.x, JumpForce);
                    JumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    IsJumping = false;
                }
            }
            if (Input.GetKeyUp(KeyCode.JoystickButton1) || Input.GetKeyUp(KeyCode.Space))
            {
                IsJumping = false;
            }

            //Horizontal = Input.GetAxisRaw("Horizontal");
            //if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 2.0f, 1.0f);
            //else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    Jump();
            //}
            if (Grounded == true)
            {
                NumDash = 1;
            }
            if (!Dashing && DasheOk == true)
            {

                if (Input.GetKeyDown(KeyCode.J) && NumDash >= 0 || Input.GetKeyDown(KeyCode.JoystickButton5) && NumDash >= 0)
                {
                    MeDuele = false;
                    PrepareDash();
                    //Anim.SetTrigger("Dash");
                    //SM.PlayDash();
                }


            }
            else
            {
                if (DashTimeCounter <= 0)
                {
                    Dashing = false;
                    DashTimeCounter = StartDashTime;
                }
                else
                {
                    DashTimeCounter -= Time.deltaTime;
                    NumDash--;
                }
            }


            //if (Input.GetKeyDown(KeyCode.Keypad5) && Time.time > LastShoot + 1.25f && BoomerEnEscena == false || Input.GetKeyDown(KeyCode.JoystickButton3) && Time.time > LastShoot + 1.25f && BoomerEnEscena == false)
            //{
            //    BoomerEnEscena = true;
            //    PasoVidaBoomer = false;
            //    StartCoroutine(Temp());
            //    SM.PlayBoomer();
            //    Shoot();
            //    LastShoot = Time.time;
            //}

            Anim.SetFloat("Running", Mathf.Abs(RB.velocity.x));
            //Anim.SetBool("Aire", !Grounded);
            //Anim.SetTrigger("Vive");
        }
        if (Vidas < 0 /*|| Crono.GetComponent<Reloj>().TiempoMuestraEnSegundos <= 0*/)
        {
            //Anim.SetTrigger("Death");
        }
        //if (Crono.GetComponent<Reloj>().TiempoMuestraEnSegundos <= 0)
        //{
        //    Vidas = 0;
        //    //SM.Muerte();

        //}
    }
    private void Jump()
    {
        if (Vidas > 0)
        {
            if (Grounded == true)
            {
                //Anim.SetTrigger("Salto");
                //SM.PlaySalto();
                Jumps = 2;
                //RB.AddForce(Vector2.up * JumpForce);
                RB.velocity = new Vector2(RB.velocity.x, JumpForce);
                JumpTimeCounter = JumpTime;
                IsJumping = true;

                if (JumpOk == false) Jumps -= 2;
                else if (JumpOk == true) Jumps--;
            }
            else if (Jumps > 0)
            {
                //Anim.SetTrigger("Salto");
                //SM.PlaySalto();
                RB.velocity = new Vector2(RB.velocity.x, JumpForce);
                JumpTimeCounter = JumpTime;
                IsJumping = true;
                Jumps--;
            }
        }

    }
    private void FixedUpdate()
    {
        if (Vidas > 0)
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            RB.velocity = new Vector2(Horizontal * Speed, RB.velocity.y);

            if (!Dashing)
            {
                //RB.velocity = Vector2.zero;
                if (Horizontal < 0.0f)
                {
                    transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                    //RB.velocity = Vector2.left * PlayerDashSpeed * Time.fixedDeltaTime;
                    DashDirection = false;
                }
                else if (Horizontal > 0.0f)
                {
                    transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
                    //RB.velocity = Vector2.right * PlayerDashSpeed * Time.fixedDeltaTime;
                    DashDirection = true;
                }
            }
            else
            {
                if (DashDirection == false)
                {
                    //transform.localScale = new Vector3(-1.0f, 2.0f, 1.0f);
                    RB.velocity = Vector2.left * PlayerDashSpeed * Time.fixedDeltaTime;
                }
                else if (DashDirection == true)
                {
                    //transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
                    RB.velocity = Vector2.right * PlayerDashSpeed * Time.fixedDeltaTime;
                }

            }
        }
        if (Vidas < 0)
        {
            //Anim.SetTrigger("Death");
            //SM.Muerte();
        }
    }
    void PrepareDash()
    {
        Dashing = true;
    }
    private void Shoot()
    {
        //if (Vidas > 0)
        //{
        //    Anim.SetTrigger("Ataque");
        //    BoomerEnEscena = true;
        //    Vector3 direction;
        //    if (transform.localScale.x == 1) direction = Vector2.right;
        //    else direction = Vector2.left;
        //    if (Vertical > 0.5f)
        //    {
        //        direction = Vector2.up;
        //    }
        //    GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        //    bullet.GetComponent<BulletScript>().SetDirection(direction);
        //}


    }
    public void Dolor()
    {
        MeDuele = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D Obj)
    {
        
        if (Obj.tag == "Boomer" && PasoVidaBoomer == true)
        {
            BoomerEnEscena = false;
            PasoVidaBoomer = false;
        }
        if (Obj.tag == "Babosa" && MeDuele == true)
        {
            Vidas--;
            MeDuele = false;
            if (Vidas > 0)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                StartCoroutine(Temp2());
            }
            if (Vidas <= 0)
            {
                //Crono.GetComponent<Reloj>().Muere();
                //Destroy(this.gameObject);
                //Anim.SetTrigger("Death");
                MeDuele = true;
            }
        }
        //if (Obj.tag == "Item")
        //{
        //    //audioSource.Play();
        //    LogicaPuntos.puntaje += 15;
        //    Destroy(Obj.gameObject);
        //    SM.PlaySelect();
        //}
        //if (Obj.tag == "ItemLife")
        //{
        //    //audioSource.Play();
        //    Vidas++;
        //    Destroy(Obj.gameObject);
        //    SM.PlaySelect();
        //}
        //if (Obj.tag == "ItemDash")
        //{
        //    //audioSource.Play();
        //    DasheOk = true;
        //    Destroy(Obj.gameObject);
        //    PoderesDash.GetComponent<Animator>().SetTrigger("DashSi");
        //    CF.GetComponent<CameraFollow>().SigueCam = true;
        //    PuertaMazmorra.GetComponent<Animator>().SetTrigger("OjoI");
        //    LogicaPuntos.puntaje += 50;
        //    SM.PlaySelect();
        //}
        //if (Obj.tag == "ItemSalto")
        //{
        //    //audioSource.Play();
        //    JumpOk = true;
        //    Destroy(Obj.gameObject);
        //    PoderesJump.GetComponent<Animator>().SetTrigger("Salto");
        //    CF.GetComponent<CameraFollow>().SigueCam = true;
        //    PuertaMazmorra.GetComponent<Animator>().SetTrigger("OjoD");
        //    LogicaPuntos.puntaje += 50;
        //    SM.PlaySelect();
        //}
    }
    //public void MuerteFin()
    //{
    //    Crono.GetComponent<Reloj>().Muere();
    //    //Anim.SetTrigger("Vive");
    //}
    void SendSound(AudioClip _clip)
    {
        //SM.PlaySE(_clip);
    }
    IEnumerator Temp()
    {
        yield return new WaitForSeconds(tiempo * Time.deltaTime);

        PasoVidaBoomer = true;

    }
    IEnumerator Temp2()
    {
        yield return new WaitForSeconds(tiempoInmune * Time.deltaTime);
        GetComponent<SpriteRenderer>().color = Color.white;
        MeDuele = true;
    }
}
