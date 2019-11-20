using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellContainer : MonoBehaviour {
    public string spellContained;

    public ISpell onPickUp()
    {
        return returnGoodSpell();
    }

    private ISpell returnGoodSpell()
    {
        switch (spellContained)
        {
            case "MoveSpell":
                return new MoveSpell();
            case "TimeSpell":
                return new TimeSpell();
            case "MorphSpell":
                return new MorphSpell();
            case "CreateSpell":
                return new CreateSpell();
            case "TeleSpell":
                return new TeleSpell();
            default:
                Debug.Log("This spell doesn't exist");
                return null;
        }
    }
}
