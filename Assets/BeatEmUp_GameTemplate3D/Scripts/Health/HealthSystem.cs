using TMPro;
using UnityEngine;

public class HealthSystem : MonoBehaviour {

	public int MaxHp = 20;
	public int CurrentHp = 20;
	public bool invulnerable;
	public delegate void OnHealthChange(float percentage, GameObject GO);
	public static event OnHealthChange onHealthChange;


	public PlayerCombat _playerCombat;

	void Start(){
		SendUpdateEvent();
		_playerCombat = GetComponent<PlayerCombat>();
	}

	//substract health
	public void SubstractHealth(int damage){
		if(!invulnerable){

			//reduce hp
			CurrentHp = Mathf.Clamp(CurrentHp -= damage, 0, MaxHp);

            //Health reaches 0
            //if (isDead()) gameObject.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
            if (isDead() && _playerCombat != null)
                _playerCombat.Death();
            else if (isDead() && _playerCombat == null) gameObject.SendMessage("Death", SendMessageOptions.DontRequireReceiver);
        }

		//update Health Event
		SendUpdateEvent();
	}

	//add health
	public void AddHealth(int amount){
		CurrentHp = Mathf.Clamp(CurrentHp += amount, 0, MaxHp);
		SendUpdateEvent();
	}
		
	//health update event
	public void SendUpdateEvent(){
		float CurrentHealthPercentage = 1f/MaxHp * CurrentHp;
		if(onHealthChange != null) onHealthChange(CurrentHealthPercentage, gameObject);
	}

	//death
	bool isDead(){
		return CurrentHp == 0;
	}
}
