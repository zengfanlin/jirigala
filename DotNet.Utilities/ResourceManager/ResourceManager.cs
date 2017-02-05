//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace DotNet.Utilities
{
    /// <summary>
    /// ResourceManager
    /// 资源管理器
    /// 
    ///	修改纪录
    ///		2007.05.16 版本：1.0 JiRiGaLa	重新调整主键的规范化。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.16</date>
    /// </author> 
    /// </summary>
    public class ResourceManager
    {
        private volatile static ResourceManager instance = null;
        private static object locker = new Object();
        public static ResourceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ResourceManager();
                        }
                    }
                }
                return instance;
            }
        }

        private string folderPath = string.Empty;
        public SortedList<String, Resources> languageResources = new SortedList<String, Resources>();

        public void Serialize(Resources resources, string filePath)
        {
            ResourcesSerializer.Serialize(filePath, resources);
        }

        public void Init(string filePath)
        {
            folderPath = filePath;
            DirectoryInfo directoryInfo = new DirectoryInfo(filePath);
            languageResources.Clear();
            if (!directoryInfo.Exists)
            {
                return;
            }
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            for (int i = 0; i < fileInfo.Length; i++)
            {
                Resources resources = ResourcesSerializer.DeSerialize(fileInfo[i].FullName);
                resources.createIndex();
                languageResources.Add(resources.language, resources);
            }
        }

        public Hashtable GetLanguages()
        {
            Hashtable hashtable = new Hashtable();
            IEnumerator<KeyValuePair<String, Resources>> iEnumerator = languageResources.GetEnumerator();
            while (iEnumerator.MoveNext())
            {
                hashtable.Add(iEnumerator.Current.Key, iEnumerator.Current.Value.displayName);
            }
            return hashtable;
        }

        public Hashtable GetLanguages(string path)
        {
            Hashtable hashtable = new Hashtable();
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (!directoryInfo.Exists)
            {
                return hashtable;
            }
            FileInfo[] fileInfo = directoryInfo.GetFiles();
            for (int i = 0; i < fileInfo.Length; i++)
            {
                Resources resources = ResourcesSerializer.DeSerialize(fileInfo[i].FullName);
                hashtable.Add(resources.language, resources.displayName);
            }
            return hashtable;
        }

        public Resources GetResources(string filePath)
        {
            Resources resources = new Resources();
            if (File.Exists(filePath))
            {
                resources = ResourcesSerializer.DeSerialize(filePath);
                resources.createIndex();
            }
            return resources;
        }

        public string Get(string language, string key)
        {
            if (string.IsNullOrEmpty(language))
            {
                language = "zh-CHS";
            }
            if (!languageResources.ContainsKey(language))
            {
                return string.Empty;
            }
            return languageResources[language].Get(key);
        }
    }
}