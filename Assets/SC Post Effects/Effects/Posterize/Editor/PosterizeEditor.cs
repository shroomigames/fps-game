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
    public sealed class PosterizeEditor : Editor {} }
#else
    [PostProcessEditor(typeof(Posterize))]
    public sealed class PosterizeEditor : PostProcessEffectEditor<Posterize>
    {
        SerializedParameterOverride intensity;

        public override void OnEnable()
        {
            intensity = FindParameterOverride(x => x.amount);
        }

        public override void OnInspectorGUI()
        {
            SCPE_GUI.DisplayDocumentationButton("posterize");

            PropertyField(intensity);
        }
    }
}
#endif
