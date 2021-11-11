using System;
using System.Collections.Generic;


namespace CheatSheet_Win.Util
{
    //TODO:计划是取消配置文件
    public class ConfigManager
    {

        //属性
        //设置的条目
        public bool Start_Up { get; set; } = true;
        public bool Single_Mode { get; set; } = true;
        public string ShortCut { get; set; } = "Alt+S";
        public string Sub_Address { get; set; } = "";
        


        //单例模式
        private static ConfigManager instance;
        private ConfigManager() { }
        public static ConfigManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ConfigManager();
            }
            return instance;
        }


        //方法
        //1.从数据库中获得设置
        public void Get_Config_From_DB()
        {

        }


        //2.往数据库存设置
        public void Save_Config_To_DB() { }


        

    }
}
