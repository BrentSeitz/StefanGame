using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CharacterClass : MonoBehaviour {

    protected string characterName;
    
    protected int characterStrength;
    protected int characterWeight;
    protected int characterStrikingSkill;
    protected int characterGrapplingSkill;
    protected int characterCounteringSkill;

    public CharacterClass characterOpponent;
    public bool isPlayerCharacter;
    protected int grappleResetCounter;
    

    public Button button_Option1;
    public Button button_Option2;
    public Button button_Option3;

    //public bool stateCurrent;
    public bool phase1;
    public bool[] phase2;
    public bool[] phase3;
    public bool[] phase4;
    public bool phase5;


    public string grapplingAnimationStatePhase1;
    public string grapplingAnimationPhase1_to_Phase2a;
    public string grapplingAnimationPhase1_to_Phase2b;

    public string grapplingAnimation_Phase2a_to_Phase3a_Via_2a1Success;
    public string grapplingAnimation_Phase2a_to_Phase3a_Via_2a2Success;
    public string grapplingAnimation_Phase2a_to_Phase3b_Via_2a3Success;
    public string grapplingAnimation_Phase2a_to_Phase3b_Via_2a4Success;

    public string grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure;

    public string grapplingAnimation_Phase2a_to_Phase2b_Via_2aFailure;
    public string grapplingAnimation_Phase2a_to_phase2b_Via2a2Failure;
    public string grapplingAnimation_Phase2a_to_Phase2a5_Via_2aFailure;
    public string grapplingAnimation_Phase2a_to_Phase2a5_Via_2a1Failure;

    public string grapplingAnimation_Phase3a_to_Phase4b_via_4aSuccess;
    public string grapplingAnimation_Phase3a_to_Phase4c_via_4aFailure;
    public string grapplingAnimation_Phase3a_to_Phase4d_via_4aCriticalFailure;

    public string grapplingAnimation_Phase3b_to_Phase5c_via_3bPlayerChoice;

    public string grapplingAnimation_Phase4c_to_Phase3a_via_3fFailure;
    public string grapplingAnimation_Phase4c_to_Phase4a_via_3gCriticalFailure;
    public string grapplingAnimation_Phase4c_to_Phase4d_via_4cCriticalSuccess;

    public string grapplingAnimation_Phase4b_to_Phase5a_via_4bPlayerChoice;
    public string grapplingAnimation_Phase4b_to_Phase5b_via_4bPlayerChoice;
    public string grapplingAnimation_Phase4b_to_Phase5c_via_4bPlayerChoice;


    public string grapplingAnimationPhase2a5_to_EndState2a5ChokeOut;
    public string grapplingAnimationPhase4d_to_EndState4dChokeOut;
    public string grapplingAnimationPhase5ab_to_EndState5abKnockChokeOut;
    public string grapplingAnimationPhase5c_to_EndStateArmBar;
    public string grapplingAnimationPhase3b_to_EndStateBrokenArm;




    public void Initialize(string Name, int CS, int CW, int CSS, int CGS, int CCS, bool isPC)
    {
        characterStrength = CS;
        characterWeight = CW;
        characterStrikingSkill = CSS;
        characterGrapplingSkill = CGS;
        characterCounteringSkill = CCS;
        characterName = Name;
        isPlayerCharacter = isPC;

        phase2 = new bool[2];
        phase3 = new bool[2];
        phase4 = new bool[3];

        grappleResetCounter = 0;


        grapplingAnimationStatePhase1 = "Both Characters are in Neutral";
        grapplingAnimationPhase1_to_Phase2a = "The Player Character has the upper hand on their opponent";
        grapplingAnimationPhase1_to_Phase2b = "The Opponent has the opperhand on the Player Character";

        grapplingAnimation_Phase2a_to_Phase3a_Via_2a1Success = (characterName + " performs a double-leg take-down on " + characterOpponent.GetCharacterName() + ", they have now mounted their Opponent");
        grapplingAnimation_Phase2a_to_Phase3a_Via_2a2Success = (characterName + " performs a Leg-Sweep into Mount take-down on  " + characterOpponent.GetCharacterName() + ", they have now mounted their Opponent");
        grapplingAnimation_Phase2a_to_Phase3b_Via_2a3Success = (characterName + " performs a Leg-Sweep on " + characterOpponent.GetCharacterName() + ", they now have their Opponent in a standing Armbar");
        grapplingAnimation_Phase2a_to_Phase3b_Via_2a4Success = (characterName + " performs a Uchimata on " + characterOpponent.GetCharacterName() + ", they now have their Opponent in a standing armbar");

        grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure = (characterName + " performs a reversal of  " + characterOpponent.GetCharacterName() + "'s Guillotine Choke Hold, they now have the Upper Hand on their Opponent");

        grapplingAnimation_Phase2a_to_Phase2b_Via_2aFailure = (characterName + " performs a reversal of  " + characterOpponent.GetCharacterName() + "'s UpperHand, they now have the Upper Hand on their Opponent");
        grapplingAnimation_Phase2a_to_phase2b_Via2a2Failure = (characterName + " performs a reversal of  " + characterOpponent.GetCharacterName() + "'s LegSweep, they now have the Upper Hand on their Opponent");
        grapplingAnimation_Phase2a_to_Phase2a5_Via_2aFailure = (characterName + " performs a Guillotine Choke Hold on " + characterOpponent.GetCharacterName() + ", they now have a Guillotine Choke on their Opponent");
        grapplingAnimation_Phase2a_to_Phase2a5_Via_2a1Failure = (characterName + " performs a Guillotine Choke Hold on  " + characterOpponent.GetCharacterName() + " in response to their opponent's Double-Leg takedown attempt, they now have a Guillotine Choke on their Opponent"); ;

        grapplingAnimation_Phase3a_to_Phase4b_via_4aSuccess = (characterName + " passes the guard of " + characterOpponent.GetCharacterName() + ", they now have the Full Mount on their Opponent");
        grapplingAnimation_Phase3a_to_Phase4c_via_4aFailure = (characterName + " performs a Full Guard of " + characterOpponent.GetCharacterName() + "'s Mount, they now have the Full Guard on their Opponent");
        grapplingAnimation_Phase3a_to_Phase4d_via_4aCriticalFailure = (characterName + " performs a Triangle Choke on " + characterOpponent.GetCharacterName() + "'s Mount, they now have the Triangle Choke on their Opponent");

        grapplingAnimation_Phase3b_to_Phase5c_via_3bPlayerChoice = (characterName + " performs a Grounded Arm Bar on " + characterOpponent.GetCharacterName() + "out of their Standing ArmBar, they now have the Grounded Arm Bar on their Opponent");

        grapplingAnimation_Phase4c_to_Phase3a_via_3fFailure = (characterName + " performs a Mount on  " + characterOpponent.GetCharacterName() + "'s Full Guard, they now have the Mount on their Opponent");
        grapplingAnimation_Phase4c_to_Phase4a_via_3gCriticalFailure = (characterName + " performs a Full Mount on " + characterOpponent.GetCharacterName() + "'s Full Guard, they now have the Full Mount on their Opponent");
        grapplingAnimation_Phase4c_to_Phase4d_via_4cCriticalSuccess = (characterName + " performs a Triangle Choke on " + characterOpponent.GetCharacterName() + " from their own Full Guard, they now have the Triangle Choke Hold on their Opponent");

        grapplingAnimation_Phase4b_to_Phase5a_via_4bPlayerChoice = (characterName + " performs a Full Naked Choke on " + characterOpponent.GetCharacterName() + " from their own Full Mount, they now have the Grounded Full Naked Choke on their Opponent");
        grapplingAnimation_Phase4b_to_Phase5b_via_4bPlayerChoice = (characterName + " performs a Ground and Pound on " + characterOpponent.GetCharacterName() + " from their own Full Mount, they now have Began Pounding on their Opponent");
        grapplingAnimation_Phase4b_to_Phase5c_via_4bPlayerChoice = (characterName + " performs a Grounded ArmBar on " + characterOpponent.GetCharacterName() + " from their own Full Mount, they now have the Grounded Arm Bar on their Opponent");


        grapplingAnimationPhase2a5_to_EndState2a5ChokeOut = (characterName + " has now Choked Out " + characterOpponent.GetCharacterName());
        grapplingAnimationPhase4d_to_EndState4dChokeOut = (characterName + " has now Choked Out " + characterOpponent.GetCharacterName());
        grapplingAnimationPhase5ab_to_EndState5abKnockChokeOut = (characterName + " has now Choked Out " + characterOpponent.GetCharacterName());
        grapplingAnimationPhase5c_to_EndStateArmBar = (characterName + " has now Subdued " + characterOpponent.GetCharacterName());
        grapplingAnimationPhase3b_to_EndStateBrokenArm = (characterName + " has now Broken the Arm of " + characterOpponent.GetCharacterName());
    }


    public CharacterClass(int CS, int CW, int CSS, int CGS, int CCS, bool isPC)
    {
        characterStrength = CS;
        characterWeight = CW;
        characterStrikingSkill = CSS;
        characterGrapplingSkill = CGS;
        characterCounteringSkill = CCS;
        isPlayerCharacter = isPC;
        phase2 = new bool[2];
        phase3 = new bool[2];
        phase4 = new bool[3];

        grappleResetCounter = 0;
}

    public void Grapple()
    {
        if(isPlayerCharacter == true)
        {
            phase1 = true;

            for(int i = 0; i < 4; i++)
            {
                Phase1Handler();
                Phase2Handler();
                Phase3Handler();
                Phase4Handler();
                Debug.Log("i" + i);
            }
                
        }
        
    }


    public void Phase1Handler()
    {
        if (phase1 == true)
        {
            if (CompareGrapplingChecks() < 0)
            {
                phase1 = false;
                characterOpponent.phase1 = false;
                phase2[1] = true;
                characterOpponent.phase2[0] = true;
                Debug.Log(grapplingAnimationPhase1_to_Phase2b);
            }
            else
            {
                phase1 = false;
                characterOpponent.phase1 = false;
                phase2[0] = true;
                characterOpponent.phase2[1] = true;
                Debug.Log(grapplingAnimationPhase1_to_Phase2a);
            }
        }
    }

    public void Phase2Handler()
    {
        if (phase2[0] == true)
        {
            int storeResult = CompareGrapplingChecks();
            if (storeResult < 0)
            {
                phase2[0] = false;
                characterOpponent.phase2[1] = false;
                if (storeResult > -6)
                {
                    characterOpponent.phase2[0] = true;
                    phase2[1] = true;
                    grappleResetCounter++;
                    if (storeResult > -4)
                        Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase2b_Via_2aFailure);
                    else
                        Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_phase2b_Via2a2Failure);
                }
                else
                {
                    if (storeResult > -8)
                        Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase2a5_Via_2a1Failure);
                    else
                        Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase2a5_Via_2aFailure);
                    if (CompareGrapplingChecks() < 0)
                        Debug.Log(characterOpponent.grapplingAnimationPhase2a5_to_EndState2a5ChokeOut);
                    else
                    {
                        //Insert Counter Option HereCompare Counter to Grapple
                        if (1 == 0)
                        {
                            Debug.Log("Counter the guilotine");
                        }
                        else
                        {
                            Debug.Log(grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure);
                            grappleResetCounter++;
                        }

                    }
                }
            }
            else
            {
                phase2[0] = false;
                //characterOpponent.phase2[1] = false;
                if (storeResult <= 5 || characterGrapplingSkill <= 4)
                    Debug.Log(grapplingAnimation_Phase2a_to_Phase3a_Via_2a1Success);
                else if (storeResult <= 7 || characterGrapplingSkill <= 6)
                    Debug.Log(grapplingAnimation_Phase2a_to_Phase3a_Via_2a2Success);
                else if (storeResult <= 9 || characterGrapplingSkill <= 9)
                    Debug.Log(grapplingAnimation_Phase2a_to_Phase3b_Via_2a3Success);
                else if (storeResult <= 11 || characterGrapplingSkill > 9)
                    Debug.Log(grapplingAnimation_Phase2a_to_Phase3b_Via_2a4Success);

                if (storeResult <= 7 || characterGrapplingSkill < 7)
                    phase3[0] = true;
                else
                    phase3[1] = true;
            }
        }
        else if (phase2[1] == true)
        {
            int storeResult = CompareGrapplingChecks();
            if (storeResult > 0)
            {
                phase2[1] = false;
                characterOpponent.phase2[0] = false;
                if (storeResult <= 7)
                {
                    characterOpponent.phase2[1] = true;
                    phase2[0] = true;
                    grappleResetCounter++;
                    if (storeResult <= 5)
                        Debug.Log(grapplingAnimation_Phase2a_to_Phase2b_Via_2aFailure);
                    else
                        Debug.Log(grapplingAnimation_Phase2a_to_phase2b_Via2a2Failure);
                }
                else
                {
                    if (storeResult <= 9)
                        Debug.Log(grapplingAnimation_Phase2a_to_Phase2a5_Via_2a1Failure);
                    else
                        Debug.Log(grapplingAnimation_Phase2a_to_Phase2a5_Via_2aFailure);
                    if (CompareGrapplingChecks() > 0)
                    {
                        DisengageGrappling();
                        Debug.Log(grapplingAnimationPhase2a5_to_EndState2a5ChokeOut);
                    }
                    else
                    {
                        //Insert Counter Option HereCompare Counter to Grapple
                        if (1 == 0)
                        {
                            Debug.Log("Opponent counters the guilotine");
                        }
                        else
                        {
                            characterOpponent.phase2[0] = true;
                            phase2[1] = true;
                            Debug.Log(characterOpponent.grapplingAnimation_Phase2a5_to_Phase2a_Via_3dFailure);
                            grappleResetCounter++;
                        }

                    }
                }
            }
            else
            {
                phase2[1] = false;
                characterOpponent.phase2[0] = false;
                if (storeResult >= -5 || characterOpponent.characterGrapplingSkill <= 4)
                    Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase3a_Via_2a1Success);
                else if (storeResult >= -7 || characterOpponent.characterGrapplingSkill <= 6)
                    Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase3a_Via_2a2Success);
                else if (storeResult >= -9 || characterOpponent.characterGrapplingSkill <= 9)
                    Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase3b_Via_2a3Success);
                else if (storeResult >= -11 || characterOpponent.characterGrapplingSkill > 9)
                    Debug.Log(characterOpponent.grapplingAnimation_Phase2a_to_Phase3b_Via_2a4Success);

                if (storeResult <= -7 || characterOpponent.characterGrapplingSkill < 7)
                    characterOpponent.phase3[1] = true;
                else
                    characterOpponent.phase3[0] = true;
            }
        }

    }

    public void Phase3Handler()
    {
        if (phase3[0] == true)
        {
            
            phase3[0] = false;
            int storeResult = CompareGrapplingChecks();
            if (storeResult < 0)
            {
                if (storeResult >= -8)
                {
                    characterOpponent.phase4[1] = true;
                    Debug.Log(characterOpponent.grapplingAnimation_Phase3a_to_Phase4c_via_4aFailure);
                }
                else
                {
                    characterOpponent.phase4[2] = true;
                    Debug.Log(characterOpponent.grapplingAnimation_Phase3a_to_Phase4d_via_4aCriticalFailure);
                }
            }
            else
            {
                phase4[0] = true;
                Debug.Log(grapplingAnimation_Phase3a_to_Phase4b_via_4aSuccess);
            }
        }
        else if (phase3[1] == true)
        {
            /*bool isYielding = true;
            while (isYielding)
            {
                while(!(button_Option1.||))
            }*/
            //Come back and work out yeilding;
            if (1 == 0)
            {

            }
            else
                Debug.Log(grapplingAnimation_Phase3b_to_Phase5c_via_3bPlayerChoice);
            DisengageGrappling();
        }
        else if (characterOpponent.phase3[0] == true)
        {

            characterOpponent.phase3[0] = false;
            int storeResult = CompareGrapplingChecks();
            if (storeResult > 0)
            {
                if (storeResult <= 8)
                {
                    phase4[1] = true;
                    Debug.Log(grapplingAnimation_Phase3a_to_Phase4c_via_4aFailure);
                }
                else
                {
                    phase4[2] = true;
                    Debug.Log(grapplingAnimation_Phase3a_to_Phase4d_via_4aCriticalFailure);
                }
            }
            else
            {
                characterOpponent.phase4[0] = true;
                Debug.Log(characterOpponent.grapplingAnimation_Phase3a_to_Phase4b_via_4aSuccess);
                DisengageGrappling();
            }
        }
        else if (characterOpponent.phase3[1] == true)
        {
            /*bool isYielding = true;
            while (isYielding)
            {
                while(!(button_Option1.||))
            }*/
            //Come back and work out yeilding;
            if (1 == 0)
            {

            }
            else
                Debug.Log(characterOpponent.grapplingAnimation_Phase3b_to_Phase5c_via_3bPlayerChoice);
        }
    }

    public void Phase4Handler()
    {
        if(phase4[0] == true)
        {
            phase4[0] = false;
            Debug.Log("The character will make a choice. For now, we assume 5a");
            if (1 == 0)
                Debug.Log(grapplingAnimationPhase5c_to_EndStateArmBar);
            else
                Debug.Log(grapplingAnimationPhase5ab_to_EndState5abKnockChokeOut);
            grappleResetCounter = 3;
            DisengageGrappling();
        }
        else if(phase4[1] == true)
        {
            phase4[1] = false;
            int storeResult = CompareGrapplingChecks();
            if (storeResult > 0)
            {
                phase4[2] = true;
                Debug.Log(grapplingAnimation_Phase4c_to_Phase4d_via_4cCriticalSuccess);
            }
            else
            {
                if (storeResult <= -8)
                {
                    characterOpponent.phase4[0] = true;
                    Debug.Log(characterOpponent.grapplingAnimation_Phase4c_to_Phase4a_via_3gCriticalFailure);
                }
                else
                {
                    characterOpponent.phase3[0] = true;
                    Debug.Log(characterOpponent.grapplingAnimation_Phase4c_to_Phase3a_via_3fFailure);
                }
                    
            }
        }
        else if (characterOpponent.phase4[0] == true)
        {
            characterOpponent.phase4[0] = false;
            Debug.Log("The character will make a choice. For now, we assume 5a");
            if (1 == 0)
                Debug.Log(characterOpponent.grapplingAnimationPhase5c_to_EndStateArmBar);
            else
                Debug.Log(characterOpponent.grapplingAnimationPhase5ab_to_EndState5abKnockChokeOut);
            grappleResetCounter = 3;
            DisengageGrappling();
        }
        else if (characterOpponent.phase4[1] == true)
        {
            characterOpponent.phase4[1] = false;
            int storeResult = CompareGrapplingChecks();
            if (storeResult < 0)
            {
                characterOpponent.phase4[2] = true;
                Debug.Log(characterOpponent.grapplingAnimation_Phase4c_to_Phase4d_via_4cCriticalSuccess);
            }
            else
            {
                if (storeResult >= 8)
                {
                    characterOpponent.phase4[0] = true;
                    Debug.Log(grapplingAnimation_Phase4c_to_Phase4a_via_3gCriticalFailure);
                }
                else
                {
                    characterOpponent.phase3[0] = true;
                    Debug.Log(grapplingAnimation_Phase4c_to_Phase3a_via_3fFailure);
                }

            }
        }
    }

    public int CompareGrapplingChecks()
    {
        System.Random rnd = new System.Random();
        int grapplingCheckValue = ((rnd.Next(0, 8) + rnd.Next(0, 8) + rnd.Next(0, (2*(characterGrapplingSkill))) + characterStrength) - ((rnd.Next(0, 6) + rnd.Next(0, 6) + rnd.Next(0, (2*(characterOpponent.characterGrapplingSkill))) + characterOpponent.characterStrength)));
        Debug.Log(grapplingCheckValue);
        return grapplingCheckValue;
    }

    public void ResetToNeutralGrappling()
    {
        for (int i = 0; i < phase2.Length; i++)
            phase2[i] = false;
        for (int i = 0; i < phase3.Length; i++)
            phase3[i] = false;
        for (int i = 0; i < phase4.Length; i++)
            phase4[i] = false;
        phase5 = false;
        phase1 = true;


        for (int i = 0; i < phase2.Length; i++)
            characterOpponent.phase2[i] = false;
        for (int i = 0; i < phase3.Length; i++)
            characterOpponent.phase3[i] = false;
        for (int i = 0; i < phase4.Length; i++)
            characterOpponent.phase4[i] = false;
        phase5 = false;
        phase1 = false;

    }

    public void DisengageGrappling()
    {
        ResetToNeutralGrappling();
        grappleResetCounter = 0;
        characterOpponent.grappleResetCounter = 0;

    }
    public void SetStrength(int CS)
    {
        characterStrength = CS;
    }
    public int GetStrength()
    {
        return characterWeight;
    }

    public void SetWeight(int CW)
    {
        characterWeight = CW;
    }
    public int GetWeight()
    {
        return characterWeight;
    }

    public void SetStrikingSkill(int CSS)
    {
        characterStrikingSkill = CSS;
    }
    public int GetStrikingSkill()
    {
        return characterStrikingSkill;
    }

    public void SetGrapplingSkill(int CGS)
    {
        characterGrapplingSkill = CGS;
    }
    public int GetGrapplingSkill()
    {
        return characterGrapplingSkill;
    }

    public void SetCounteringSkill(int CCS)
    {
        characterCounteringSkill = CCS;
    }
    public int GetCounteringSkill()
    {
        return characterCounteringSkill;
    }

    public void SetCharacterName(string CN)
    {
        characterName = CN;
    }
    public string GetCharacterName()
    {
        return characterName;
    }
}
