using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hareket : MonoBehaviour
{
    private Rigidbody rb;

    public float hiz = 5f;

    public TMP_Text nesneMetni;

    public int nesneSayimi = 0;

    public TMP_Text zamanlayici;

    public int geriSayimSuresi = 30;

    private float geriSayim;

    public TMP_Text sonucMetni;

    public Transform target;

    public Vector3 target_offset;

    public float moveSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        target_offset = transform.position - target.position;

        metniGuncelleme();

        geriSayim = geriSayimSuresi;

       geriSayimMetni_Guncelleme();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);

        geriSayim -= Time.deltaTime;

        geriSayimMetni_Guncelleme();

        

        if(geriSayim <= 0){

            geriSayim = 0;
        }
            

           /* if (Input.GetKey(KeyCode.A))
        {
            // Karakteri sola hareket ettir
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // Karakteri sağa hareket ettir
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        } */
        }
        private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Kapsül"))
        {
            Destroy(collision.gameObject);
            nesneSayimi++;
            metniGuncelleme();
        }
        if (collision.gameObject.CompareTag("Hedef"))
       {
             if (nesneSayimi >= 7)
                {
            if (geriSayimSuresi > 0)
                {
                sonucMetni.text = "Kazandın!";
                }
                else 
                {
                sonucMetni.text = "Yetişemedin";
                }
                }
                else
                {
                if (geriSayimSuresi > 0)
                {
                     sonucMetni.text = "Kitabımı Evde Unutmuşum Hocam :(";
                }
                else
                {
                 sonucMetni.text = "ÖSS yi kaçırdın Nazif :(";
                }
                    }

                }
        } 

        public void metniGuncelleme(){

        nesneMetni.text = "" + nesneSayimi.ToString();
    }

    void geriSayimMetni_Guncelleme(){

        int saniye = (int)Mathf.Ceil(geriSayim);

        zamanlayici.text = "Kalan Saniye:" + saniye.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        // "x2" tag'li objeyle temas edildiğinde
        if (other.CompareTag("x2"))
        {
            // Yok edilen obje sayısını iki katına çıkar
            nesneSayimi *= 2;
        }
        // "+3" tag'li objeyle temas edildiğinde
        else if (other.CompareTag("+3"))
        {
            // Yok edilen obje sayısını üç artır
            nesneSayimi += 3;
        }
        else if (other.CompareTag("bolu2"))
        {
            // Yok edilen obje sayısını üç artır
            nesneSayimi /= 2;
        }
        else if (other.CompareTag("-3"))
        {
            // Yok edilen obje sayısını üç artır
            nesneSayimi -= 3;
        }
        else if (other.CompareTag("+4"))
        {
            // Yok edilen obje sayısını üç artır
            nesneSayimi += 4;
        }
        else if (other.CompareTag("-5"))
        {
            // Yok edilen obje sayısını üç artır
            nesneSayimi -= 5;
        }
        else if (other.CompareTag("süre-1")){

            geriSayim -= 1;
            zamanlayici.text = "Kalan Saniye:" + geriSayim.ToString();
        }
        else if (other.CompareTag("süre-5")){

            geriSayim -= 5;
            zamanlayici.text = "Kalan Saniye:" + geriSayim.ToString();
        }
        UpdateObjectCountText();
        
    }
    private void UpdateObjectCountText()
    {
        nesneMetni.text = nesneSayimi.ToString(); // Metin kutusunu güncelle
    }
    
    }



