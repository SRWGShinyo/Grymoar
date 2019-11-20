using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class SpellController : MonoBehaviour {
    [Serializable]
    public struct spellPicture
    {
        public string nameSpell;
        public Sprite imageSpell;
    }

    [Serializable]
    public struct spellAudio
    {
        public string nameSpell;
        public AudioClip audio;
    }

    public List<ISpell> allAvailableSpells = new List<ISpell>();

    public spellPicture[] picturesForSpell;
    public spellAudio[] audioForSPell;

    private Dictionary<string, AudioClip> audios = new Dictionary<string, AudioClip>();
    private Dictionary<string, Sprite> images = new Dictionary<string, Sprite>();

    private ParticleSystem haloEffect;
    private ParticleSystem mouseTrailEffect;
    private Color initColor;
    private bool isSpellActivated = false;

    public Image spellActive;
    public Text descrSpell;
    public AudioSource formula;
    public string activatedSpell;

    public Sprite defaultSprite;
    public string defaultText;

    public int activeSpell = -1;
	// Use this for initialization
	void Start () {
        haloEffect = GetComponentInChildren<ParticleSystem>();
        mouseTrailEffect = GameObject.Find("MouseCursor").GetComponentInChildren<ParticleSystem>();
        ParticleSystem.MainModule main = mouseTrailEffect.main;
        initColor = main.startColor.Evaluate(1);

        spellActive = GameObject.Find("SpellSprite").GetComponent<Image>();
        spellActive.sprite = defaultSprite;
        descrSpell = GameObject.Find("SpellText").GetComponent<Text>();
        descrSpell.text = defaultText;

        setUpDictionaries();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            activateSpell();
        if (Input.GetMouseButtonUp(0))
            deActivateSpell();

        if (Input.GetMouseButtonDown(1) && allAvailableSpells.Count > 1)
            rotateSpell();

        if (isSpellActivated)
            allAvailableSpells[activeSpell].applyEffect();
    }

    private void setUpDictionaries()
    {
        foreach (spellPicture sP in picturesForSpell)
        {
            images.Add(sP.nameSpell, sP.imageSpell);
        }

        foreach (spellAudio sA in audioForSPell)
        {
            audios.Add(sA.nameSpell, sA.audio);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spell")
        {
            if (isSpellActivated)
                deActivateSpell();

            GameObject.Find("PickUp").GetComponent<AudioSource>().Play();
            allAvailableSpells.Add(collision.gameObject.GetComponent<SpellContainer>().onPickUp());
            ParticleSystem pe = collision.gameObject.GetComponentInChildren<ParticleSystem>();
            ParticleSystem pE = Instantiate(pe) as ParticleSystem;
            pE.transform.position = collision.gameObject.transform.position;
            Destroy(collision.gameObject);
            pE.Play();
            activeSpell = allAvailableSpells.Count - 1;
            setUpSpell(allAvailableSpells[allAvailableSpells.Count - 1]);
        }
    }

    private void rotateSpell()
    {
        GameObject.Find("TurnPage").GetComponent<AudioSource>().Play();
        if (isSpellActivated)
            deActivateSpell();

        int safeIndex = activeSpell + 1;
        safeIndex %= allAvailableSpells.Count;
        activeSpell = safeIndex;

        setUpSpell(allAvailableSpells[activeSpell]);
    }

    public void setUpSpell(ISpell spell)
    {
        activatedSpell = spell.nameS;
        ParticleSystem.MainModule halo = haloEffect.main;
        halo.startColor = spell.haloColor;

        if (Input.GetMouseButton(0))
        {
            activateSpell();
        }


        if (spellActive)
            spellActive.sprite = images[activatedSpell];
        if (formula)
            formula.clip = audios[activatedSpell];
        if (descrSpell)
            descrSpell.text = spell.descr;
    }

    private void activateSpell()
    {
        if (activeSpell == -1)
            return;

        ParticleSystem.MainModule mouse = mouseTrailEffect.main;
        mouse.startColor = allAvailableSpells[activeSpell].particleColorGradient;
        isSpellActivated = true;
        GameObject.Find("SpellActive").GetComponent<AudioSource>().Play();
    }

    private void deActivateSpell()
    {
        if (activeSpell == -1)
            return;

        ParticleSystem.MainModule mouse = mouseTrailEffect.main;
        mouse.startColor = initColor;
        allAvailableSpells[activeSpell].unApplyEffect();
        isSpellActivated = false;
    }
}
