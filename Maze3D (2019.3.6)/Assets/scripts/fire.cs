using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    public AudioClip gunshot;
    //public AudioClip noammo;
    public Camera fpsCam;
    public int bullets;
    public GameObject sight;
    public GameObject sparkle;
    public GameObject hole;
    public AudioClip hurt;
    public int enemycount ;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        bullets = 20;
        enemycount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemycount<=0)
        {
            Destroy(GameObject.Find("big wall"));
        }
        AudioSource audio = GetComponent<AudioSource>();
        if (Input.GetButtonDown("Fire1") )
        {
            bullets--;
            if (bullets >= 0)
            {
                audio.PlayOneShot(gunshot);
                RaycastHit hit;
                if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, 100f))
                {
                    Instantiate(sparkle, hit.point, Quaternion.identity);
                    Instantiate(hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
                    print("You hit in " + hit.collider.gameObject.tag);
                    if(hit.collider.gameObject.tag=="enemy")
                    {
                        Destroy(GameObject.Find("Enemy"));
                        AudioSource audio1 = GetComponent<AudioSource>();
                        audio1.PlayOneShot(hurt);
                    }
                    if (hit.collider.gameObject.tag == "enemy2")
                    {
                        Destroy(GameObject.Find("Enemy"));
                        AudioSource audio1 = GetComponent<AudioSource>();
                        audio1.PlayOneShot(hurt);
                        enemycount--;
                    }
                }    
                GameObject.Find("UI_bullet_count").GetComponent<UnityEngine.UI.Text>().text = "Bullets: " + bullets +"/20";
            }
            else
            {
                //audio.PlayOneShot(noammo);
            }
        }
        if(bullets<0 && !GameObject.Find("FPSController").GetComponent<detect_collision>().isGun)
        {
            GameObject.Find("UI_bullet_count").GetComponent<UnityEngine.UI.Text>().text = "NO AMMO";
            GameObject.Find("UI_texture_gun").GetComponent<RawImage>().enabled = false;
            sight.SetActive(false);
        }
    }

}
