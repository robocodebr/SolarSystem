using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeSpeed : MonoBehaviour
{
    public TMP_Dropdown planetDropDown;
    public Scrollbar orbitScrollBar;
    public Scrollbar axisScrollBar;

    List<TMP_Dropdown.OptionData> planetsOptions;
    CanvasGroup cg;
    GameObject currentPlanet;
    float maxSpeed;
    private void Start()
    {
        planetsOptions = planetDropDown.options;
        cg = orbitScrollBar.GetComponent<CanvasGroup>();
        currentPlanet = GameObject.Find("Sun");
        maxSpeed = currentPlanet.GetComponent<Planet>().maxSpeed;
        changePlanetDropDown(planetDropDown);

        planetDropDown.onValueChanged.AddListener(delegate { changePlanetDropDown(planetDropDown); });
        orbitScrollBar.onValueChanged.AddListener(delegate { changeOrbitScroll(orbitScrollBar); });
        axisScrollBar.onValueChanged.AddListener(delegate { changeAxisScroll(axisScrollBar); });
    }
    void Update()
    {
       
    }

    void changeOrbitScroll(Scrollbar orbitScroll) {
        currentPlanet.GetComponent<Planet>().speed = orbitScroll.value * maxSpeed;
    }

    void changeAxisScroll(Scrollbar axisScroll)
    {
        currentPlanet.GetComponent<Planet>().selfSpeed = axisScroll.value * maxSpeed;
    }

    void changePlanetDropDown(TMP_Dropdown change) {
        string planetText = planetsOptions[change.value].text;
        currentPlanet = GameObject.Find(planetText);
        setOrbitScrollBarState(planetText);
        Planet planet = currentPlanet.GetComponent<Planet>();
        if(planetText != "Sun") orbitScrollBar.value = planet.speed / maxSpeed;
        axisScrollBar.value = planet.selfSpeed / maxSpeed;
    }

    void setOrbitScrollBarState(string planet) {
        if (planet == "Sun")
        {
            cg.interactable = false;
            cg.alpha = 0;
        }
        else
        {
            cg.interactable = true;
            cg.alpha = 1;
        }
    }
}
