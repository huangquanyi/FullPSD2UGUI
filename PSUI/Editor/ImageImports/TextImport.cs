﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

namespace PSDUIImporter
{
    public class TextImport : IImageImport
    {
        public UINode DrawImage(Image image, UINode parent)
        {
            UINode node = PSDImportUtility.InstantiateItem(PSDImporterConst.PREFAB_PATH_TEXT, image.name,parent);
            UnityEngine.UI.Text myText = node.GetComponent<Text>();
            PSDImportUtility.SetPictureOrLoadColor(image, myText);

            float size;
            if (float.TryParse(image.arguments[2], out size))
            {
                myText.fontSize = (int)size;
            }

            myText.text = image.arguments[3];

            RectTransform rectTransform = myText.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(image.size.width, image.size.height);
            rectTransform.anchoredPosition = new Vector2(image.position.x, image.position.y);
            return node;
        }
    }
}
