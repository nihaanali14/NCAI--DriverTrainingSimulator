﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;



    // generic class for Menus, implementing Singleton pattern
    public abstract class Menu<T> : Menu where T : Menu<T>
    {
        // reference to public and private instances
        private static T _instance;
        public static T Instance { get { return _instance; } }

        // self-destruct if another instance already exists
        protected virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = (T)this;
            }
        }

        // unset the instance if this object is destroyed
        protected virtual void OnDestroy()
        {
            _instance = null;
        }

    // simplifies syntax to open a menu
    public static void Open()
    {

     //  print("menu manager " + MenuManager.Instance + " menu " + Instance);
     if (MenuManager.Instance != null && Instance != null)
        {
         //  print("Open menu");
            MenuManager.Instance.OpenMenu(Instance);
       }
    }
}

    // base class for Menus
    [RequireComponent(typeof(Canvas))]
    public abstract class Menu : MonoBehaviour
    {
        public virtual void OnBackPressed()
        {
            if (MenuManager.Instance != null)
            {
                MenuManager.Instance.CloseMenu();
            }
        }

       
    }

