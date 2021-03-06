﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
#if SCPE
using UnityEditor.Rendering.PostProcessing;
using UnityEngine.Rendering.PostProcessing;
#endif

namespace SCPE
{
#if !SCPE
    public sealed class SpeedLinesEditor : Editor {} }
#else
    [PostProcessEditor(typeof(SpeedLines))]
    public sealed class SpeedLinesEditor : PostProcessEffectEditor<SpeedLines>
    {
        SerializedParameterOverride intensity;
        SerializedParameterOverride size;
        SerializedParameterOverride falloff;
        SerializedParameterOverride noiseTex;

        public override void OnEnable()
        {
            intensity = FindParameterOverride(x => x.intensity);
            size = FindParameterOverride(x => x.size);
            falloff = FindParameterOverride(x => x.falloff);
            noiseTex = FindParameterOverride(x => x.noiseTex);
        }

        public override void OnInspectorGUI()
        {
            SCPE_GUI.DisplayDocumentationButton("speed-lines");

            SCPE_GUI.DisplayVRWarning();

            PropertyField(intensity);
            PropertyField(size);
            PropertyField(falloff);
            PropertyField(noiseTex);
        }
    }
}
#endif