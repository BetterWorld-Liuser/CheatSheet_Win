using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CheatSheet_Win.Util
{

    /// <summary>
    /// 此类用来对订阅进行下载
    /// </summary>
    public class DownloadManager
    {
        public event Action DownloadCompleted;
        private static DownloadManager instance;
        private DownloadManager() { }

        public static DownloadManager GetInstance()
        {
            if (instance == null)
            {
                instance = new DownloadManager();

            }
            return instance;
        }


        /// 下载订阅地址的字符串
        public async Task<string> DownLoadFileAsync()
        {

            //从设置(Cmanager)中读取
            ConfigManager configManager = ConfigManager.GetInstance();
            using (HttpClient httpClient = new())
            {
                Uri adress = new(configManager.Sub_Address);
                //添加文件下载完成后的事件
                try
                {
                    string responseBody = await httpClient.GetStringAsync(configManager.Sub_Address);
                    
                    DownloadCompleted?.Invoke();
                    return responseBody;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", ex.Message);
                    return "";
                }

            }

        }
    }
}
