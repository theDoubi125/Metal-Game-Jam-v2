using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {


    public enum EnumRooms :int { Parking, Concert, Reserve }

    public EnumRooms currentRoom = EnumRooms.Parking;

    public int bombeState = 0;


    bool isInConcert()
    {
        return currentRoom == EnumRooms.Concert;
    }


    public void setRoom(EnumRooms room)
    {
        if (currentRoom == room) return;
        currentRoom = room;
        changeRoomEvent();
    }

    void changeRoomEvent()
    {
        print("Change room : " + currentRoom+" "+ bombeState);

        SetTelephoneTextDependingOnBombeState();

        if (!TelephoneBehaviour.instance.isTelephoneVisible() && (currentRoom == EnumRooms.Parking || currentRoom == EnumRooms.Reserve))
            TelephoneBehaviour.instance.InitMovePhone();
    }


    void SetTelephoneTextDependingOnBombeState()
    {

        if (bombeState == 0)
        {
           bombeState++;
        }


        switch (bombeState)
        {
            case 1:
                TelephoneBehaviour.SetDialogText("La mission d’infiltration se passe mal ! J’ai appris qu’il y avait une bombe dans la salle !! Je ne sais pas s’ils l’ont remarquée, il n’y a pas de signe de panique mais pourtant ils agissent tous trop bizarrement! ");
                TelephoneBehaviour.instance.setDialogVisibility(true);
                TelephoneBehaviour.SetTelephoneText("Bonjour Agent 118 218, calmez vous, essayez de trouver la bombe", false);
                break;
            case 2:
                /*
                TelephoneBehaviour.SetDialogText("Il y a une sorte d’énigme incompréhensible sur la bombe, c’est un damier avec des chiffres.");
                TelephoneBehaviour.instance.setDialogVisibility(true);
                TelephoneBehaviour.SetTelephoneText("Oh mon dieu !! Vous êtes tombé sur la nouvelle génération Willi Waller 2016. Vous devez absolument résoudre cette énigme pour désamorcer la bombe. Surtout ne tentez rien d’autre.", isInConcert());
                */
                break;
            case 3:
               // TelephoneBehaviour.SetTelephoneText("", isInConcert());
                break;
        }

    }
            




    // Use this for initialization
    void Start () {
        TelephoneBehaviour.SetTelephoneText("Cher agent, je reste en contact avec vous par messages.", false);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
