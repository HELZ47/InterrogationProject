using UnityEngine;
using System.Collections;

public class Fact : AttackDetails {

	public Fact()
	{

	}

	public Fact(string who, string when, string how, string where){
		setHow(how);
		setWhere(where);
		setWho(who);
		setWhen(when);
	}

}
