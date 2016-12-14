using UnityEngine;
using System.Collections;

public class Weapon  {

    private float Effectivity;
    private Sprite weaponSprite;

    public float GetEffectivity()
    {
        return Effectivity;
    }
    public Sprite GetSprite()
    {
        return weaponSprite;

    }
	public Weapon(float e, Sprite w)
    {
        Effectivity = e;
        weaponSprite = w;


        
    }
	
	
}
