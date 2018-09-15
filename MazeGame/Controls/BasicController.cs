using System.Net;
using System.Management;
using System.Security.Cryptography;
using System.Text;

namespace MazeGame.Controls
{
    public static class BasicController
    {
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://clients3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Generates unique token for computer based on CPU ID.
        /// Must add System.Management namespace to refrences.
        /// In solution explorer find Refrences -> right click -> Add refrence -> System.Management
        /// </summary>
        /// <returns>
        /// Unique Token hashed wiht SHA256
        /// </returns>
        public static string GenerateUniqueToken()
        {
            string sProcessorID = "";

            string sQuery = "SELECT ProcessorId FROM Win32_Processor";

            ManagementObjectSearcher oManagementObjectSearcher = new ManagementObjectSearcher(sQuery);

            ManagementObjectCollection oCollection = oManagementObjectSearcher.Get();

            foreach (ManagementObject oManagementObject in oCollection)
            {
                sProcessorID = (string)oManagementObject["ProcessorId"];
            }

            return ComputeSha256Hash(sProcessorID);
        }

        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            { 
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
 
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
