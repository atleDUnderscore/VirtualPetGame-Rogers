using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GeneratePet : MonoBehaviour
{
    string tempName;
    [SerializeField] Button genButton;
    [SerializeField] TMP_Text petDisp;
    [SerializeField] Slider hungerSlider;
    [SerializeField] Slider energySlider;
    [SerializeField] Slider happSlider;
    [SerializeField] GameObject titleUI;
    [SerializeField] GameObject gameUI;
    float hunger;
    float energy;
    float happiness;
    int hungry;
    int tired;
    int bored;
    bool petGend;
    Pet Pet;
    bool tempPet;
    Pet pet = new Pet(null);

    public void OnGenPet()
    {
        pet.Name = tempName;
        Debug.Log(pet.Name);
        petGend = true;
        Debug.Log(pet.Hunger);
        hunger = pet.Hunger;
        hungerSlider.value = pet.Hunger;
        energySlider.value = pet.Energy;
        happSlider.value = pet.Happiness;
        gameUI.SetActive(true);
        titleUI.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

        genButton.interactable = false;
        petDisp.text = ":D";
        petGend = false;
        tempPet = false;
        hunger = 100f;
        energy = 100f;
        happiness = 100f;
        titleUI.SetActive(true);
        gameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        if (petGend)
        {
            if(hungry + tired + bored >= 2)
            {
                StartCoroutine(AnimalServices());
                petDisp.text = ":(";
            }
            else if(hungry + tired + bored < 2)
            {
                StopAllCoroutines();
                if(hungry + tired + bored == 1)
                {
                    petDisp.text = ":/";
                }
                if(hungry + tired + bored == 0)
                {
                    petDisp.text = ":D";
                }
            }

            if (hunger >= 0.005f)
            {
                pet.HungerMinus();
                hunger -= .005f;
                hungerSlider.value = pet.Hunger;
                hungry = 0;

            }
            else
            {
                Debug.Log("No More Food");
                hungry = 1;
            }

            if (happiness >= 0.01f)
            {
                pet.HappinessMinus();
                happiness -= .01f;
                happSlider.value = pet.Happiness;
                bored = 0;

            }
            else
            {
                Debug.Log("sadge");
                bored = 1;
            }

            if (energy >= 0.0025f)
            {
                pet.EnergyMinus();
                energy -= .0025f;
                energySlider.value = pet.Energy;
                tired = 0;

            }
            else
            {
                Debug.Log("*yawn*");
                tired = 1;
            }
        }
    }

    

    public void PetName(string pName)
    {
        tempName = pName;
        genButton.interactable = true;
    }

    IEnumerator AnimalServices()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("GameScene");
    }

    public void Eat()
    {
        pet.Eat();
        hunger += 25;
    }

    public void Rest()
    {
        pet.Rest();
        energy = 100;
    }

    public void Play()
    {
        pet.Play();
        happiness += 25;
    }
    
   
}
