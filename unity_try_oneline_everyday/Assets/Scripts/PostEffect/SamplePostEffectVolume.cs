using System;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
[VolumeComponentMenu("SamplePostEffect")]
public class SamplePostEffectVolume : VolumeComponent // VolumeComponentを継承する
{
    public bool IsActive() => tintColor != Color.white;

    // Volumeコンポーネントで設定できる値にはxxxParameterクラスを使う
    public ColorParameter tintColor = new ColorParameter(Color.white);
}
