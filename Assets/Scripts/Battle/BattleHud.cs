using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;
    [SerializeField] Text statusText;
    [SerializeField] Color psnColour;
    [SerializeField] Color brnColour;
    [SerializeField] Color slpColour;
    [SerializeField] Color parColour;
    [SerializeField] Color frzColour;
    [SerializeField] Image statusBackground;

    Dictionary<ConditionID, Color> statusColours;

    Pokemon _pokemon;

    public void SetData(Pokemon pokemon)
    {
        _pokemon = pokemon;

        nameText.text = pokemon.Base.Name;
        levelText.text = "Lv." + pokemon.Level;
        hpBar.SetHP((float) pokemon.HP / pokemon.MaxHp);

        statusColours = new Dictionary<ConditionID, Color>()
        {
            {ConditionID.psn, psnColour },
            {ConditionID.brn, brnColour },
            {ConditionID.slp, slpColour },
            {ConditionID.par, parColour },
            {ConditionID.frz, frzColour }
        };

        SetStatusText();
        _pokemon.OnStatusChanged += SetStatusText;
    }

    void SetStatusText()
    {
        if (_pokemon.Status == null)
        {
            statusText.text = "";
            statusBackground.color = Color.clear;
        }
        else
        {
            statusText.text = _pokemon.Status.Id.ToString().ToUpper();
            statusBackground.color = statusColours[_pokemon.Status.Id];
        }
    }

    public IEnumerator UpdateHP()
    {
        if (_pokemon.HpChanged)
        {
            yield return hpBar.SetHPSmooth((float)_pokemon.HP / _pokemon.MaxHp);
            _pokemon.HpChanged = false;
        }
    }

}
