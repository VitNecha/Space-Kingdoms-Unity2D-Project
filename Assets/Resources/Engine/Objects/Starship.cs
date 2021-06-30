using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Starship")]
public class Starship : ScriptableObject
{
    [SerializeField] string owner;
    [SerializeField] string starship;
    [SerializeField] int health = 100;
    [SerializeField] int damageMin = 13;
    [SerializeField] int damageMax = 26;
    [SerializeField] int actionPoints = 25;

    public int getHealth() { return this.health; }
    public int getDamageMin() { return this.damageMin; }
    public int getDamageMax() { return this.damageMax; }
    public int getActionPoints() { return this.actionPoints; }
    protected void damage(int damage) {
        if (damage < this.health) this.health = this.health - damage;
        else this.health = 0;
    }
    protected void reduceActionPoint(int points) { this.actionPoints = this.actionPoints - points; }

    public int hit(Starship target) {
        int damage = (damageMax + damageMin) / 2;
        target.damage(damage);
        reduceActionPoint(12);
        return damage;
    }

    // Update is called once per frame
    
}
