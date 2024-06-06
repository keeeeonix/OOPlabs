using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace OOPlab24
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Skipjack
        {
            private readonly byte[] key;
            private static readonly byte[] fTable = new byte[] {
                 0xa3, 0xd6, 0x39, 0x8e, 0xc6, 0x2b, 0x63, 0x7e, 0x37, 0x51, 0x2c, 0x7f, 0x0d, 0x1e, 0x3e, 0x64,
        0x58, 0xdc, 0xe3, 0x29, 0xb1, 0xf4, 0x89, 0x06, 0xe0, 0xd9, 0xfa, 0x18, 0x35, 0x45, 0xf2, 0xab,
        0xb0, 0x2a, 0x72, 0xa2, 0xe4, 0xb5, 0x9d, 0x40, 0xc0, 0x59, 0xe5, 0x5d, 0x85, 0xd8, 0x2f, 0x3f,
        0x47, 0x3b, 0x27, 0x71, 0x0c, 0xe7, 0x49, 0x22, 0xe1, 0x32, 0x57, 0xc5, 0x76, 0xa8, 0x4d, 0x6e,
        0xfb, 0x7c, 0x50, 0xa0, 0x4f, 0x1b, 0x7b, 0xdd, 0x4a, 0xd3, 0x83, 0x68, 0x42, 0xc3, 0xc9, 0x6c,
        0x95, 0xda, 0xc7, 0x0e, 0x25, 0x96, 0x8d, 0x5b, 0x2e, 0x5a, 0xf1, 0x52, 0x2d, 0x46, 0xd0, 0x66,
        0x94, 0xce, 0xf0, 0x9e, 0x5f, 0xbc, 0x65, 0xe9, 0xcb, 0x20, 0x81, 0x29, 0xb6, 0x4e, 0xff, 0x6f,
        0x9a, 0xb8, 0x34, 0x60, 0x1d, 0xdb, 0x3a, 0xe6, 0x53, 0x3d, 0xc8, 0x74, 0x1c, 0x5e, 0x5c, 0xef,
        0xe2, 0x61, 0xe8, 0x89, 0x31, 0xfd, 0x9f, 0xed, 0xcf, 0x73, 0x56, 0xbe, 0x1f, 0x91, 0x70, 0xd1,
        0x4b, 0xa7, 0xde, 0x7a, 0xc4, 0x97, 0x6d, 0xec, 0xd5, 0x48, 0x79, 0x8f, 0x17, 0x2d, 0x3c, 0x4c,
        0x71, 0xa1, 0x6a, 0xe5, 0x41, 0x26, 0x36, 0x12, 0x13, 0xd2, 0x10, 0x67, 0x24, 0xac, 0xba, 0x02,
        0xae, 0x0f, 0xf6, 0x86, 0xe8, 0xa5, 0xf8, 0xc1, 0x4c, 0xad, 0x77, 0x82, 0x3e, 0xb3, 0x51, 0x23,
        0x14, 0xbf, 0x93, 0x7e, 0x87, 0xb2, 0xa4, 0x75, 0x5b, 0x43, 0x6f, 0x11, 0x65, 0x7b, 0xb0, 0x2a,
        0x89, 0xf9, 0xf5, 0xd1, 0x52, 0x37, 0x83, 0xc2, 0x2b, 0x46, 0xf0, 0xb4, 0x16, 0xd4, 0xa9, 0x91,
        0x42, 0x34, 0x79, 0x0a, 0x22, 0xcf, 0x6c, 0xf7, 0x0d, 0xb8, 0xe1, 0x4e, 0x50, 0x1b, 0x1d, 0xda,
        0x7e, 0xa6, 0x3e, 0x68, 0x98, 0xf4, 0x3c, 0x6e, 0xd9, 0xf2, 0xb6, 0xac, 0xd8, 0x85, 0x92, 0xe7
            };
            public Skipjack(byte[] key)
            {
                if(key.Length != 10)
                {
                    throw new ArgumentException("Довжина ключа повинна становити 10 байтів");
                }
                this.key = key;
            }
            public byte[] Encrypt(byte[] plaintext)
            {
                if (plaintext.Length != 8)
                {
                    throw new ArgumentException("Довжина тексту повинна становити 8 байтів");
                }

                ushort[] w = new ushort[4];
                w[0] = BitConverter.ToUInt16(plaintext, 0);
                w[1] = BitConverter.ToUInt16(plaintext, 2);
                w[2] = BitConverter.ToUInt16(plaintext, 4);
                w[3] = BitConverter.ToUInt16(plaintext, 6);

                for(int round = 0; round <32; round++)
                {
                    ushort g1 = w[0];
                    ushort g2 = w[1];
                    ushort g3 = w[2];
                    ushort g4 = w[3];

                    ushort g = G(g1, round);
                    w[0] = (ushort)(g ^ g4 ^ (round + 1));
                    w[1] = (ushort)(g2 + g);
                    w[2] = (ushort)(G(g3, round + 1) ^ g1);
                    w[3] = g1;
                }

                byte[] ciphertext = new byte[8];
                Buffer.BlockCopy(w, 0, ciphertext, 0, 8);
                return plaintext;
            }

            private ushort G(ushort w, int round)
            {
                byte k1 = key[(4 * round) % 10];
                byte k2 = key[(4 * round + 1) % 10];
                byte k3 = key[(4 * round + 2) % 10];
                byte k4 = key[(4 * round +3) % 10];

                byte g1 = (byte)(w >> 8);
                byte g2 = (byte)(w & 0xFF);

                g2 ^= fTable[g1 ^ k1];
                g1 ^= fTable[g2 ^ k2];
                g2 ^= fTable[g1 ^ k3];
                g1 ^= fTable[g2 ^ k4];

                return (ushort)((g1 << 8) | g2);
            }
        }

        public class Snefru
        {
            private const int rounds = 8;
            private const int hash_size = 32;
            private const int block_size = 16;

            public static byte[] ComputeHash(byte[] input)
            {
                byte[] hash = new byte[hash_size];
                Buffer.BlockCopy(input, 0, hash, 0, Math.Min(hash_size, input.Length));

                for(int round = 0; round < rounds; round++)
                {
                    byte[] temp = new byte[block_size];
                    for(int i = 0; i < hash_size; i += block_size)
                    {
                        Buffer.BlockCopy(hash, i, temp, 0, block_size);
                        EncryptBlock(temp, round);
                        Buffer.BlockCopy(temp, 0, hash, i, block_size);
                    }
                }
                return hash;
            }
            private static void EncryptBlock(byte[] block, int round)
            {
                for (int i = 0; i < block_size; i++) 
                {
                    block[i] ^= (byte)(round + i);
                }
            }
        }

        public class PKZIP
        {
            private static readonly uint[] crcTable = new uint[256];

            static PKZIP()
            {
                for (uint i = 0; i < 256; i++)
                {
                    uint crc = i;
                    for (uint j = 8;  j > 0; j--)
                    {
                        if ((crc & 1) == 1)
                            crc = (crc >> 1) ^ 0xEDB88320;
                        else
                            crc >>= 1;
                    }
                    crcTable[i] = crc;
                }
            }
            public static byte[] Encrypt(byte[] data, string password)
            {
                byte[] key = InitializeKey(password);
                byte[] encryptedData = new byte[data.Length];

                for (int i = 0;i < data.Length;i++)
                {
                    byte temp = (byte)(data[i] ^ (key[2] >> 8));
                    UpdateKey(key, temp);
                    encryptedData[i] = temp;
                }
                return encryptedData;
            }

            public static byte[] GenerateRandomBytes(int length)
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    byte[] randomBytes = new byte[length];
                    rng.GetBytes(randomBytes);
                    return randomBytes;
                }
            }

            private static byte[] InitializeKey(string password)
            {
                byte[] key = new byte[3];
                foreach (char c in password)
                {
                    UpdateKey(key, (byte)c);
                }
                return key;
            }

            private static void UpdateKey(byte[] key, byte bytevalue)
            {
                key[0] = (byte)(crcTable[(key[0] ^ bytevalue) & 0xFF] ^ (key[0] >> 8));
                key[1] = (byte)((key[1] + (byte)key[0]) * 134775813 + 1);
                key[2] = (byte)(crcTable[(key[2] ^ (byte)(key[1] >> 24)) & 0xFF] ^ (key[2] >> 8));
            }
        }

        private async void btnSkipjack_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Думаємо...";
            string result = await Task.Run(() =>
            {
                byte[] key = Encoding.UTF8.GetBytes("1234567890");
                Skipjack skipjack = new Skipjack(key);
                byte[] encrypted = skipjack.Encrypt(Encoding.UTF8.GetBytes("12345678"));
                return BitConverter.ToString(encrypted);
            });
            textBox1.Text = result;
        }

        private async void btnSnefru_Click(object sender, EventArgs e)
        {
            textBox2.Text = "Думаємо...";
            string result = await Task.Run(() =>
            {
                byte[] hash = Snefru.ComputeHash(Encoding.UTF8.GetBytes("12345678"));
                return BitConverter.ToString(hash);
            });
            textBox2.Text = result;
        }

        private async void btnPKZIP_Click(object sender, EventArgs e)
        {
            textBox3.Text = "Думаємо...";
            string result = await Task.Run(() =>
            {
                byte[] encryptedData = PKZIP.Encrypt(Encoding.UTF8.GetBytes("12345678"), "password");
                byte[] randomBytes = PKZIP.GenerateRandomBytes(16);
                return BitConverter.ToString(encryptedData) + "\n" + BitConverter.ToString(randomBytes);
            });
            textBox3.Text = result;
        }
    }
}
