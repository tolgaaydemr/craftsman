﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class PlayerController : MonoBehaviour
{
    //degiskenler
    public bool alive = true;
    public bool jump = false;
    public bool slide = false;
    public bool ground = false;
    public bool moveAction = false;
    public int ganimet = 0;
    public int laneNumber = 1;
    public static int sayac = 3;
    public float xMovement = 5f;
    public float yMovement;
    public float zMovement;
    public float xCoordinates;
    public int number = 0;
    public Canvas Test;
    public Canvas TestFalse;
    public Text txt;
    public static string ans;
    public string soru;
    public string cevap;
    
    
    
    public Transform spawnPos;
    private GUIStyle guiStyle = new GUIStyle();
    public Animator anim;

    
    
    string[,] questions = new string[,] {
                                        {"Türkiye'nin Başkenti İstanbuldur.", "Yanlis"}, 
                                        {"2x10 işleminin sonucu 20'dir.", "Dogru"}, 
                                        {"30 Ağustos Ulusal Eğemenlik ve Çocuk Bayramıdır", "Yanlis"}, 
                                        {"Cumhuriyet 29 Ekim 1923 tarihinde ilan edilmiştir.", "Dogru"},
                                        {"8x10 işleminin sonucu 80'dir.", "Dogru"}, 
                                        {"Türkiye Cumhuriyetinin ilk cumhurbaşkanı Mustafa Kemal Atatürktür.", "Dogru"}, 
                                        {"Türkiyenin iki tarafı denizlerle kaplıdır.", "Yanlis"}, 
                                        {"6x7 işleminin sonucu 40'dir.", "Yanlis"}, 
                                        {"Dinazorlar nesli tükenmiş dev hayvanlardırdır", "Dogru"}, 
                                        {"İnsanlar 43 kromozomludur", "Yanlis"}, 
                                        {"Kanada bir Avrupa ülkesidir.", "Yanlis"}, 
                                        {"Türkiye'nin 7 bölgesi vardır", "Dogru"}, 
                                        {"34x12 işleminin sonucu 298'dir.", "Yanlis"}, 
                                        {"Geceleri yönümüzü bulmak için Ay'ı kullanabiliriz.", "Yanlis"}, 
                                        {"Erciyes Dağı volkanik bir dağdır", "Dogru"}, 
                                        {"Gülü ile meşhur ilimiz Isparta'dır", "Dogru"}, 
                                        {"İstiklal Şairi olarak anılan şairimiz Mehmet Akif Ersoy'dur", "Dogru"}, 
                                        {"Duvara asılı bir haritanın sağı her zaman Batıyı gösterir ", "Yanlis"}, 
                                        {"Çanakkale Savaşı sırasında 215 kg’lık mermiyi tek başına kaldıran Türk askeri Seyit Onbaşıdır.", "Dogru"}, 
                                        {"İstanbul Ege Bölgesinde yer almaktadır.", "Yanlis"}, 
                                        {"Tebriklerr Oyunu kazandınız", "Haha"}, 
                                        };
    
    void Start()
    {
        StartCoroutine(milis());
        transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);
        anim = GetComponent<Animator>();
        anim.SetBool("isRun", false);
        alive = true;
        Test.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        
        xCoordinates = transform.position.x;
        transform.Translate(new Vector3(xMovement, yMovement, zMovement) * Time.deltaTime);
        if (alive == true && sayac == 0)
        {
            anim.SetBool("isRun", true);
            zMovement = 5f;

        }
        else if (alive == true && sayac > 0)
        {
            xMovement = 0; yMovement = 0; zMovement = 0;
        }
        else if (alive == false) {
            xMovement = 0; yMovement = 0; zMovement = 0;
        }
        duzeltme();

        if (Input.GetKey(KeyCode.S)) { slide = true; moveAction = true; Hareket(slide, 1); }
        else { slide = false; Hareket(slide, 1); }

        if (Input.GetKey(KeyCode.W) && ground == true) { jump = true; moveAction = true; Hareket(jump, 2); }
        else { jump = false; Hareket(jump, 2); }

        if (Input.GetKeyDown(KeyCode.A) && laneNumber >= 0) { Hareket(true, 3); }
        if (Input.GetKeyDown(KeyCode.D) && laneNumber <= 2) { Hareket(true, 4); }

        if (xCoordinates >= 0.000f && xCoordinates <= 0.050f && (laneNumber == 0) && alive == true && sayac == 0 && moveAction == true) {
            xMovement = 0f; moveAction = false; }

        if (xCoordinates >= 0.950f && xCoordinates <= 1.05f && (laneNumber == 1) && alive == true && sayac == 0 && moveAction == true) {
            xMovement = 0f; moveAction = false; }

        if (xCoordinates >= 1.950f && xCoordinates <= 2.05f && (laneNumber == 2) && alive == true && sayac == 0 && moveAction == true) {
            xMovement = 0f; moveAction = false; }

        

        

    }
    private void Hareket(bool etkinlik, int a)
    {
        if (a == 1)
        {
            if (etkinlik == true)
            {
                //playerCollider.height = CCCrouchHeight;
                //playerCollider.center.y = 0.1;
                //transform.Translate(0, 0f, 0.1f);
                anim.SetBool("isSlide", slide);

            }
            else if (etkinlik == false)
            {
                //playerCollider.height = CCStandHeight;
                //transform.Translate(0, 0, 0.1f);
                anim.SetBool("isSlide", slide);
            }
        }//kayma
        if (a == 2) {
            if (etkinlik == true)
            {
                anim.SetBool("isJump", etkinlik);
                yMovement = 0.0f;
                Debug.Log("Ziplama Basarili");
            }
            else if (etkinlik == false)
            {
                anim.SetBool("isJump", etkinlik);
                yMovement = 0f;
            }
        }//zipla
        if (a == 3)
        {
            Debug.Log("Sola Gecme Basarili");
            xMovement = -2f;
            if (laneNumber == 0) { laneNumber = 0; }
            if (laneNumber == 1) { laneNumber = 0; }
            if (laneNumber == 2) { laneNumber = 1; }
        }//sola gecme
        if (a == 4)
        {
            Debug.Log("Saga Gecme Basarili");
            xMovement = 2f;

            if (laneNumber == 2) { laneNumber = 2; }
            if (laneNumber == 1) { laneNumber = 2; }
            if (laneNumber == 0) { laneNumber = 1; }
        }//saga gecme
    } //Kontrolleri saglıyor
    private void duzeltme() {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = 0;
        transform.rotation = Quaternion.Euler(rotationVector);

    } //ziplarken donme problemini ortadan kaldiriyor

    private void FixedUpdate()
    {
        //lane 0
        if (xCoordinates >= 0.000f && xCoordinates <= 0.050f && (laneNumber == 0))
        {
            xMovement = 0f; transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);
        }

        //lane 1
        if (xCoordinates >= 0.950f && xCoordinates <= 1.05f && (laneNumber == 1))
        {
            xMovement = 0f; transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);
        }

        //lane 2
        if (xCoordinates >= 1.950f && xCoordinates <= 2.05f && (laneNumber == 2))
        {
            xMovement = 0f; transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime);
        }
        
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            ground = true;
        }
        else if (collision.gameObject.tag != "Ground")
        {
            ground = false;
        }
        if (collision.gameObject.tag == "Lethal") {
            
            //animasyonlu olmesi icin
            alive = false;
            xMovement = 0; yMovement = 0; zMovement = 0;
            transform.Translate(new Vector3(xMovement, yMovement, zMovement) * Time.deltaTime);
             
            
            soru = questions[number,0];
            cevap = questions[number, 1];
            Test.GetComponent<Canvas>().enabled = true; //panel is open
            txt.text = soru;
            
            anim.SetBool("isRevived", true);
            StartCoroutine(waiting());
            
            
           
            

            //sorudan sonra animasyon calisacak.
            //Doğru yanlış olarak sorular değerlendirilecek! (if else)
            
            
            
            //direkt olmesi icin
            //Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Money") {
            //etkilesime girdiginde para yok oluyor
            Destroy(collision.gameObject);
            ganimet = ganimet+ 5;
        }
    }
    private void OnGUI()
    {
        guiStyle.fontSize = 20;
        guiStyle.normal.textColor = Color.red;
        GUI.Label(new Rect(10, 20, 150, 80), "Ganimet: " + ganimet,guiStyle);
    }
   
    IEnumerator milis() {
        Debug.Log("Oyun Basliyor");
        yield return new WaitForSeconds(1);
        sayac = 3;
        yield return new WaitForSeconds(1);
        sayac = 2;
        yield return new WaitForSeconds(1);
        sayac = 1;
        yield return new WaitForSeconds(1);
        sayac = 0;
        yield return new WaitForSeconds(1);
        Debug.Log(sayac);
    }
    IEnumerator waiting(){
        Debug.Log("waiting calisti");
        
        float timer = 15f;
        for (; timer>=0.0f;timer-=0.1f)
        {
            yield return new WaitForSeconds(0.1f);
           
        if(ans!=null){
            if (cevap == ans)
            {
                Test.GetComponent<Canvas>().enabled = false;
                Debug.Log("calisti");
                txt.text = "Dogru";
                Debug.Log(ans);
                xMovement = 0; yMovement = 0; zMovement = 10f;
                anim.SetBool("isRevived", false);
                alive = true;
                ans = null;
                if(number==19)
                    number=0;
                else
                number++;
                txt.text = "";
                Debug.Log(number);
                break;
            }
             else
            {
                txt.text = "Üzgünüm yanlış cevap verdin :(";
                anim.SetBool("isDead", true);
               // Test.GetComponent<Canvas>().enabled = false;
                break;
            }
            if(timer<0)
            {
            Test.GetComponent<Canvas>().enabled = false;
            txt.text = "SureDoldu";
            anim.SetBool("isDead", true);
            }

           
        }
        
        }
        Debug.Log("waiting bitti");
         

        
        
            
        
    }
    
}
