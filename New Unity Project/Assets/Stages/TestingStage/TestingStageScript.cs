using UnityEngine;
using System.Collections;

public class TestingStageScript : MonoBehaviour {
    //public CharacterClass testingCharacter1;
    //public CharacterClass testingNPC1;

    public GameObject testingCharacter1;
    public GameObject testingNPC1;

    // Use this for initialization
    void Start () {
        testingCharacter1 = GameObject.Find("Cube: Player Character");
        testingCharacter1.AddComponent<CharacterClass>();
        
        testingNPC1 = GameObject.Find("Cube: NPC 1");
        testingNPC1.AddComponent<CharacterClass>();

        testingCharacter1.GetComponent<CharacterClass>().characterOpponent = testingNPC1.GetComponent<CharacterClass>();
        testingNPC1.GetComponent<CharacterClass>().characterOpponent = testingCharacter1.GetComponent<CharacterClass>();

        testingCharacter1.GetComponent<CharacterClass>().Initialize("PlayerCharacter", 3, 88, 3, 10, 6, true);
        testingNPC1.GetComponent<CharacterClass>().Initialize("NPC", 3, 88, 3, 8, 6, false);
        testingCharacter1.GetComponent<CharacterClass>().Initialize("PlayerCharacter", 3, 88, 3, 10, 6, true);
        
        //Debug.Log(testingCharacter1.GetComponent<CharacterClass>().grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure);
        //Debug.Log(testingCharacter1.GetComponent<CharacterClass>().grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure);

        testingCharacter1.GetComponent<CharacterClass>().Grapple();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
