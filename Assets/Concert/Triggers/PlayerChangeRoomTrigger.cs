using UnityEngine;
using System.Collections;

public class PlayerChangeRoomTrigger : MonoBehaviour {

    public PlayerState.EnumRooms associatedRoom;
    public bool isFilterValue;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            PlayerState playerState = col.gameObject.GetComponent<PlayerState>();
            if (playerState)
                playerState.setRoom(associatedRoom);

			if (playerState.currentRoom == PlayerState.EnumRooms.Concert)
			{
				TelephoneBehaviour.SetMessageVisible(false);
			}
			else
			{
				TelephoneBehaviour.SetMessageVisible(true);
			}

            AmbianceMusic ambianceMusicComponent = col.gameObject.GetComponent<AmbianceMusic>();
            if (ambianceMusicComponent)
                ambianceMusicComponent.isFilter = isFilterValue;
        }
    }
}
