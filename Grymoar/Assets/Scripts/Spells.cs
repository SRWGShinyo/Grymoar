using UnityEngine;

public interface ISpell {
    string nameS { get; }
    string descr { get;}
    string sprite { get; }

    Color particleColorGradient { get; }
    Color haloColor { get; }

    void applyEffect();
    void unApplyEffect();
}
