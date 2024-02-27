using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet
{

    string name;
    float hunger;
    float happiness;
    float energy;


    public float Energy
    {
        get { return energy; }
        set { energy = value; }
    }

    public float Happiness
    {
        get { return happiness; }
        set { happiness = value; } 
    }

    public float Hunger
    {
        get { return hunger; }
        set { hunger = value; } 
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Pet(string aName)
    {
        name = aName;
        hunger = 100;
        energy = 100;
        happiness = 100;
    }

    public void Eat()
    {
        Hunger += 25;
    }

    public void Rest()
    {
        Energy = 100;
    }

    public void Play()
    {
        Happiness += 25;
    }

    public void HungerMinus()
    {
        Hunger -= .005f;
    }

    public void EnergyMinus()
    {
        Energy -= .0025f;
    }

    public void HappinessMinus()
    {
        Happiness -= .01f;
    }

}
