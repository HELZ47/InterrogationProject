using UnityEngine;
using System.Collections;

public class AttackDetails : MonoBehaviour {

	public string where;
	public string how;
	public string when;
	public string who;
	public GameManager.AnswerType answerType;

	public AttackDetails(){
		where = "I don't know";
		how = "I don't know";
		when = "I don't know";
		who = "I don't know";
	}

	public void setWhere(string w){
		where = w;
	}

	public void setWho(string w){
		who = w;
	}

	public void setWhen(string w){
		when = w;
	}

	public void setHow(string h){
		how = h;
	}
}
