using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {


    private Weapon CurrentWeapon;
    public SpriteRenderer WeaponHolderSprite;
    private GameManager gManager;
    private bool CanRob = false;
    private Victim victim;
    public Sprite[] WeaponSprites;
    private Weapon[] weaponInventory;
    private int weaponInventoryIndex;

    void Start()
    {
        gManager = FindObjectOfType<GameManager>();
        EquipWeapon(new Weapon(100, WeaponSprites[Random.Range(0,WeaponSprites.Length)]));
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            RobVictim();
        }
    }

    void SwitchWeapon()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {

        }
            
    }

   void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "victim")
        {
            CanRob = true;
            victim = col.gameObject.GetComponent<Victim>();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "victim")
        {
            CanRob = false;
            victim = null;
        }
    }
    void RobVictim()
    {
        if (CanRob)
        {
            if(victim != null)
            {
                gManager.setMoney(gManager.getMoney()+victim.GetMoney()+CurrentWeapon.GetEffectivity());
                victim.Robbed();
                print(gManager.getMoney());
            }
        }
    }
    public void EquipWeapon(Weapon _w)
    {
        CurrentWeapon = _w;
        WeaponHolderSprite.sprite = CurrentWeapon.GetSprite();
    }
}
