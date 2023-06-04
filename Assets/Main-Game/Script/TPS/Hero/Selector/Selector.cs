using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
[SerializeField] private GameObject tps;
[SerializeField] private GameObject spn;
[SerializeField] private GameObject tce;
[SerializeField] private GameObject tnt;
[SerializeField] private GameObject selector;
[SerializeField] private TceMouvement MenuPauseTce;
[SerializeField] private SpnMouvement MenuPauseSpn;
[SerializeField] private TpsMouvement MenuPauseTps;
[SerializeField] private TntMouvement MenuPauseTnt;
public int Verifperso;


public void spawntps()
{
    tps.SetActive(true);
    selector.SetActive(false);
    Verifperso = 1;
}

public void spawnspn()
{
    spn.SetActive(true);
    selector.SetActive(false);
    Verifperso = 2;
}

public void spawntce()
{
    tce.SetActive(true);
    selector.SetActive(false);
    Verifperso = 3;
}

public void spawntnt()
{
    tnt.SetActive(true);
    selector.SetActive(false);
    Verifperso = 4;
}

//Ici on spawn Tnt

public void spawntntPause()
{
    if(tce.activeSelf == true)
    {
        tce.SetActive(false);
        tnt.SetActive(true);
        MenuPauseTce.ResumeGameTce();
        Verifperso = 4;
    }
    else{}

    if(spn.activeSelf == true)
    {
        spn.SetActive(false);
        tnt.SetActive(true);
        MenuPauseSpn.ResumeGameSpn();
        Verifperso = 4;
    }
    else{}

    if(tps.activeSelf == true)
    {
        tps.SetActive(false);
        tnt.SetActive(true);
        MenuPauseTps.ResumeGameTps();
        Verifperso = 4;
    }
    else{}
}

//Ici on spawn Tps

public void spawntpsPause()
{
    if(tce.activeSelf == true)
    {
        tce.SetActive(false);
        tps.SetActive(true);
        MenuPauseTce.ResumeGameTce();
        Verifperso = 1;
    }
    else{}

    if(spn.activeSelf == true)
    {
        spn.SetActive(false);
        tps.SetActive(true);
        MenuPauseSpn.ResumeGameSpn();
        Verifperso = 1;
    }
    else{}

    if(tnt.activeSelf == true)
    {
        tnt.SetActive(false);
        tps.SetActive(true);
        MenuPauseTnt.ResumeGameTnt();
        Verifperso = 1;
    }
    else{}
}

//Ici on spawn Spn

public void spawnspnPause()
{
    if(tce.activeSelf == true)
    {
        tce.SetActive(false);
        spn.SetActive(true);
        MenuPauseTce.ResumeGameTce();
        Verifperso = 2;
    }
    else{}

    if(tnt.activeSelf == true)
    {
        tnt.SetActive(false);
        spn.SetActive(true);
        MenuPauseTnt.ResumeGameTnt();
        Verifperso = 2;
    }
    else{}

    if(tps.activeSelf == true)
    {
        tps.SetActive(false);
        spn.SetActive(true);
        MenuPauseTps.ResumeGameTps();
        Verifperso = 2;
    }
    else{}
}

//Ici on spawn Tce

public void spawntcePause()
{
    if(tnt.activeSelf == true)
    {
        tnt.SetActive(false);
        tce.SetActive(true);
        MenuPauseTnt.ResumeGameTnt();
        Verifperso = 3;
    }
    else{}

    if(spn.activeSelf == true)
    {
        spn.SetActive(false);
        tce.SetActive(true);
        MenuPauseSpn.ResumeGameSpn();
        Verifperso = 3;
    }
    else{}

    if(tps.activeSelf == true)
    {
        tps.SetActive(false);
        tce.SetActive(true);
        MenuPauseTps.ResumeGameTps();
        Verifperso = 3;
    }
    else{}
}


}
