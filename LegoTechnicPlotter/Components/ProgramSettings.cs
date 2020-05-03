using System;
using Microsoft.SPOT;
using System.IO;
using Gadgeteer;
using System.Collections;

namespace LegoTechnicPlotter.Components
{
    public class ProgramSettings
    {
        private static ProgramSettings _instance;
        private Gadgeteer.Modules.GHIElectronics.SDCard _sdCard;

        private string _filename = "plottersettings.ini";


        private ProgramSettings(Gadgeteer.Modules.GHIElectronics.SDCard sdCard)
        {
            this._sdCard = sdCard;
        }

        public static ProgramSettings GetInstance(Gadgeteer.Modules.GHIElectronics.SDCard sdCard)
        {
            if (_instance == null)
            {
                _instance = new ProgramSettings(sdCard);
            }

            return _instance;
        }

        public string GetValue(string key)
        {
            var settingItems = this.GetSettingItems();

            foreach (var itemObject in settingItems)
            {
                SettingItem settingItem;
                if (!this.TrySettingItem(itemObject, out settingItem))
                {
                    continue;
                }

                if (!settingItem.Key.Equals(key))
                {
                    continue;
                }

                return settingItem.Value;
            }

            return string.Empty;
        }

        public void Save(string key, string value)
        {
            if (!this._sdCard.IsCardInserted)
            {
                return;
            }

            var settingItems = this.GetSettingItems();
            this.SetOrAddSetting(key, value, settingItems);

            using (StreamWriter sw = new StreamWriter(this.GetStream()))
            {
                foreach (var itemObject in settingItems)
                {
                    SettingItem settingItem;
                    if (!this.TrySettingItem(itemObject, out settingItem))
                    {
                        continue;
                    }

                    sw.WriteLine(settingItem.Key + "=" + settingItem.Value);
                }

                sw.Close();
            }
        }

        private void SetOrAddSetting(string key, string value, ArrayList settingItems)
        {
            bool wasSet = false;
            foreach (var itemObject in settingItems)
            {
                SettingItem settingItem;
                if (!this.TrySettingItem(itemObject, out settingItem))
                {
                    continue;
                }

                if (!settingItem.Key.Equals(key))
                {
                    continue;
                }

                settingItem.Value = value;
                wasSet = true;
            }

            if (!wasSet)
            {
                SettingItem si = new SettingItem();
                si.Key = key;
                si.Value = value;
                settingItems.Add(si);
            }
        }

        private bool TrySettingItem(object itemObject, out SettingItem settingItem)
        {
            settingItem = itemObject as SettingItem;

            if (settingItem == null)
            {
                return false;
            }

            return true;
        }

        private ArrayList GetSettingItems()
        {
            ArrayList al = new ArrayList();
            using (StreamReader sr = new StreamReader(this.GetStream()))
            {

                string str = string.Empty;
                while ((str = sr.ReadLine()) != null)
                {
                    string[] sa = str.Split('=');

                    SettingItem si = new SettingItem();

                    if (sa.Length >= 1)
                    {
                        si.Key = sa[0];
                    }

                    if (sa.Length >= 2)
                    {
                        si.Value = sa[1];
                    }

                    al.Add(si);
                }
            }
            return al;
        }

        private FileStream GetStream()
        {
            StorageDevice sd = this._sdCard.GetStorageDevice();
            var stream = sd.Open(this._filename, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            return stream;
        }
    }
}
