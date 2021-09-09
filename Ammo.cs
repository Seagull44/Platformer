using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speed = 15f;
    public Rigidbody2D rb;
    public static int damage = 1;
    private int bulletObject, playerObject, freeze, coinOb, Healer;
    public GameObject SparkGob;
   


    void Start()
    {
       
        rb.velocity = transform.right * speed;
        bulletObject = LayerMask.NameToLayer("Bullet");
        playerObject = LayerMask.NameToLayer("Player");
        freeze = LayerMask.NameToLayer("freeze");
        coinOb = LayerMask.NameToLayer("Coin");
        Healer = LayerMask.NameToLayer("Healer");


    }

    private void Update()
    {

        Physics2D.IgnoreLayerCollision(bulletObject, playerObject , true);
        Physics2D.IgnoreLayerCollision(bulletObject, freeze, true);
        Physics2D.IgnoreLayerCollision(bulletObject, coinOb, true);
        Physics2D.IgnoreLayerCollision(bulletObject, Healer, true);
       
    }

    private void OnTriggerEnter2D(Collider2D hitinfo)
    {
        Enemy enemy = hitinfo.GetComponent<Enemy>();
        if (enemy != null)
        {enemy.TakeDamage(damage);}
        Destroy(gameObject);

        FlyEnemy flyEnemy = hitinfo.GetComponent<FlyEnemy>();
        if (flyEnemy != null)
        {flyEnemy.TakeDamage(damage);}

        BossEye bossEye = hitinfo.GetComponent<BossEye>();
        if (bossEye != null)
        {bossEye.TakeDamage(damage);}

        BossTeleport bossTeleport = hitinfo.GetComponent<BossTeleport>();
        if (bossTeleport != null)
        {bossTeleport.TakeDamage(damage);}

        RedBoss redBoss = hitinfo.GetComponent<RedBoss>();
        if (redBoss !=null)
        {redBoss.TakeDamage(damage);}

        DestroyedDoor destroyedDoor = hitinfo.GetComponent<DestroyedDoor>();
        if (destroyedDoor != null)
        {
            Instantiate(SparkGob, transform.position, Quaternion.identity);
            destroyedDoor.TakeDamage(damage);
        }

        Keys keys = hitinfo.GetComponent<Keys>();
        if (keys !=null)
        {
            Instantiate(SparkGob, transform.position, Quaternion.identity);
            keys.TakeDamage(damage);
        }

        GoldenMiniBoss goldenMiniBoss = hitinfo.GetComponent<GoldenMiniBoss>();
        if (goldenMiniBoss !=null)
        {goldenMiniBoss.TakeDamage(damage);}


        MiniBoss miniBoss = hitinfo.GetComponent<MiniBoss>();
        if (miniBoss != null)
        {miniBoss.TakeDamage(damage);}

        Stalker stalker = hitinfo.GetComponent<Stalker>();
        if (stalker !=null)
        {stalker.TakeDamage(damage);}

        SuicideEnemy suicideEnemy = hitinfo.GetComponent<SuicideEnemy>();
        if (suicideEnemy != null)
        {suicideEnemy.TakeDamage(damage);}

        MiniBossDebuff miniBossDebuff = hitinfo.GetComponent<MiniBossDebuff>();
        if (miniBossDebuff !=null)
        {miniBossDebuff.TakeDamage(damage);}

        MiniBlinker miniBlinker = hitinfo.GetComponent<MiniBlinker>();
        if (miniBlinker != null)
        {miniBlinker.TakeDamage(damage);}

        MiniMelle miniMelle = hitinfo.GetComponent<MiniMelle>();
        if (miniMelle != null)
        {miniMelle.TakeDamage(damage);}

        Kamikadze kamikadze = hitinfo.GetComponent<Kamikadze>();
        if (kamikadze != null)
        {kamikadze.TakeDamage(damage);}
        
        Spawn spawn = hitinfo.GetComponent<Spawn>();
        if (spawn != null)
        {spawn.TakeDamage(damage);}
        
        turret Turret = hitinfo.GetComponent<turret>();
        if (Turret != null)
        {Turret.TakeDamage(damage);}

        FlyingShit flyingShit = hitinfo.GetComponent<FlyingShit>();
        if (flyingShit !=null)
        {flyingShit.TakeDamage(damage);}

        DarkMiniBoss darkMini = hitinfo.GetComponent<DarkMiniBoss>();
        if (darkMini !=null)
        {darkMini.TakeDamage(damage);}
        
        DarkBoss darkBoss = hitinfo.GetComponent<DarkBoss>();
        if (darkBoss !=null)
        {darkBoss.TakeDamage(damage);}

        BoxTrap boxTrap = hitinfo.GetComponent<BoxTrap>();
        if (boxTrap !=null)
        {boxTrap.TakeDamage(damage);}

        Crystal crystal = hitinfo.GetComponent<Crystal>();
        if (crystal !=null)
        {crystal.TakeDamage(damage);}
    }
 }

