using System.Collections.Generic;

namespace CheatSheet_Win.Model
{
    //每一对条目
    public class Pair
    {
        public string Description { get; set; }
        public string Cheat { get; set; }
    }
    //每一个分类
    public class CheatList
    {
        public string Title { get; set; }
        public List<Pair> Pairs { get; set; }
    }
    /// <summary>
    /// 显示在视图对应的模型
    /// </summary>
    public class DataModel
    {
        private static DataModel instance;
        private DataModel() { }
        public static DataModel GetInstance()
        {
            if (instance == null)
            {
                instance = new DataModel();
            }
            return instance;
        }
        public string Target { get; set; }
        public List<CheatList> CheatLists { get; set; }
    }
}
