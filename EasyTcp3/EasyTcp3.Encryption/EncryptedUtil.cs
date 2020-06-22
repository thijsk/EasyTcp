using System.Security.Cryptography.X509Certificates;
using EasyEncrypt2;
using EasyTcp.Encryption.Protocols.Tcp;
using EasyTcp.Encryption.Protocols.Tcp.Ssl;
using EasyTcp3;
using EasyTcp3.EasyTcpPacketUtils;
using EasyTcp3.Server;

namespace EasyTcp.Encryption
{
    /// <summary>
    /// Class with functions for encrypting packages
    /// </summary>
    public static class EncryptionUtil 
    {
        /// <summary>
        /// Encrypt message with EasyEncrypt
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryption">instance of easyEncrypt class</param>
        /// <returns>encrypted data</returns>
        public static T Encrypt<T>(this T data, EasyEncrypt encryption) where T : IEasyTcpPacket 
        {
            data.Data = encryption.Encrypt(data.Data);
            return data;
        }

        /// <summary>
        /// Decrypt message with EasyEncrypt
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryption">instance of easyEncrypt class</param>
        /// <returns>decrypted data</returns>
        public static T Decrypt<T>(this T data, EasyEncrypt encryption) where T : IEasyTcpPacket
        {
            data.Data = encryption.Decrypt(data.Data);
            return data;
        }

        /// <summary>
        /// Shortcut for enabling encryption 
        /// </summary>
        /// <param name="client"></param>
        /// <param name="encrypt"></param>
        public static EasyTcpClient UseEncryption(this EasyTcpClient client, EasyEncrypt encrypt)
        {
            client.Protocol = new EncryptedPrefixLengthProtocol(encrypt);
            return client;
        }

        /// <summary>
        /// Shortcut for enabling encryption 
        /// </summary>
        /// <param name="server"></param>
        /// <param name="encrypt"></param>
        public static EasyTcpServer UseEncryption(this EasyTcpServer server, EasyEncrypt encrypt)
        {
            server.Protocol = new EncryptedPrefixLengthProtocol(encrypt);
            return server;
        }
    }
}
