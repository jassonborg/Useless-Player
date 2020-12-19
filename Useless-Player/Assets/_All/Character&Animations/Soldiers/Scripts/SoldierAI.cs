using UnityEngine;

public class SoldierAI : MonoBehaviour
{
    SoldierAnimation anim;
    public GameObject gun;
    //public GameObject bullet;
    //public GameObject muzzleEffect;

    void Shoot()
    {
        //GameObject e = Instantiate(muzzleEffect, gun.transform.position, muzzleEffect.transform.rotation);
        //GameObject b = Instantiate(bullet, gun.transform.position, bullet.transform.rotation);
        //b.GetComponent<Rigidbody>().AddForce(gun.transform.right * 1000);
    }

    public void StopShooting()
    {
        CancelInvoke("Shoot");
    }

    public void StartShooting()
    {
        InvokeRepeating("Shoot", 1f, 1f);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<SoldierAnimation>();    // Get the animator component
    }

    // Update is called once per frame
    void Update()
    {
        anim.Distance();
    }

}
