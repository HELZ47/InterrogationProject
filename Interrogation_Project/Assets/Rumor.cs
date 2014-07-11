using UnityEngine;
using System.Collections;

public class Rumor : AttackDetails {

	public Rumor()
	{

	}
	
	public Rumor(string who, string when, string how, string where){
		setHow(how);
		setWhere(where);
		setWho(who);
		setWhen(when);
	}
}
