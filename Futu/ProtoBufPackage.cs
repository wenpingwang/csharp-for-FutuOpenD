using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Futu
{
    class ProtoBufPackage
    {
        private string szHeaderFlag = "FT";//包头起始标志，固定为“FT”
        private int nProtoID;//协议ID
        private byte nProtoFmtType = 0;//协议格式类型，0为Protobuf格式，1为Json格式
        private byte nProtoVer = 0;//协议版本，用于迭代兼容, 目前填0
        private int nSerialNo;//包序列号，用于对应请求包和回包, 要求递增
        private int nBodyLen;//包体长度
        private byte[] arrBodySHA1;//byte[20]
        private byte[] arrReserved = new byte[8];//byte[8]
        private byte[] bodys;//包体

        public ProtoBufPackage()
        {
            this.NSerialNo = (int)Utils.currentTimeMillis();
        }

        public byte[] pack()
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(Encoding.Default.GetBytes(SzHeaderFlag), 0, Encoding.Default.GetBytes(SzHeaderFlag).Length);//包头起始标志，固定为“FT”
            ms.Write(toLH(NProtoID), 0, toLH(NProtoID).Length);//协议ID
            ms.WriteByte(NProtoFmtType);//协议格式类型，0为Protobuf格式，1为Json格式
            ms.WriteByte(NProtoVer);//协议版本，用于迭代兼容, 目前填0
            ms.Write(toLH(NSerialNo), 0, toLH(NSerialNo).Length);//包序列号，用于对应请求包和回包, 要求递增
            ms.Write(toLH(Bodys.Length), 0, toLH(Bodys.Length).Length);//包体长度
            ArrBodySHA1 = Utils.SHA1_Encrypt(Bodys);
            ms.Write(ArrBodySHA1, 0, ArrBodySHA1.Length);
            ms.Write(ArrReserved, 0, ArrReserved.Length);//保留8字节扩展
            ms.Write(Bodys, 0, Bodys.Length);
            byte[] pack = ms.ToArray();
            ms.Close();
            return pack;
        }


        public static ProtoBufPackage unpack(MemoryStream inputStream)
        {
            ProtoBufPackage pack = new ProtoBufPackage();
            inputStream.Position = 0;

            byte[] bytes = new byte[2];
            inputStream.Read(bytes, 0, 2);

            bytes = new byte[4];
            inputStream.Read(bytes, 0, 4);
            pack.NProtoID = (int)unintbyte2long(bytes);

            bytes = new byte[2];
            inputStream.Read(bytes, 0, 2);

            bytes = new byte[4];
            inputStream.Read(bytes, 0, 4);
            pack.NSerialNo = (int)unintbyte2long(bytes);

            bytes = new byte[4];
            inputStream.Read(bytes, 0, 4);
            pack.NBodyLen = (int)unintbyte2long(bytes);

            bytes = new byte[20];
            inputStream.Read(bytes, 0, 20);
            pack.ArrBodySHA1 = bytes;

            bytes = new byte[8];
            inputStream.Read(bytes, 0, 8);
            bytes = new byte[pack.NBodyLen];

            inputStream.Read(bytes, 0, bytes.Length);
            pack.Bodys = bytes;
            inputStream.Flush();
            return pack;
        }

        public static byte[] toLH(int n)
        {
            byte[] b = new byte[4];
            b[0] = (byte)(n & 0xff);
            b[1] = (byte)(n >> 8 & 0xff);
            b[2] = (byte)(n >> 16 & 0xff);
            b[3] = (byte)(n >> 24 & 0xff);
            return b;
        }
        public static long unintbyte2long(byte[] res)
        {
            int firstByte = 0;
            int secondByte = 0;
            int thirdByte = 0;
            int fourthByte = 0;
            int index = 0;
            firstByte = (0x000000FF & ((int)res[index]));
            secondByte = (0x000000FF & ((int)res[index + 1]));
            thirdByte = (0x000000FF & ((int)res[index + 2]));
            fourthByte = (0x000000FF & ((int)res[index + 3]));
            return ((long)(firstByte | secondByte << 8 | thirdByte << 16 | fourthByte << 24)) & 0xFFFFFFFFL;
        }

        public string SzHeaderFlag { get => szHeaderFlag; set => szHeaderFlag = value; }
        public int NProtoID { get => nProtoID; set => nProtoID = value; }
        public byte NProtoFmtType { get => nProtoFmtType; set => nProtoFmtType = value; }
        public byte NProtoVer { get => nProtoVer; set => nProtoVer = value; }
        public int NSerialNo { get => nSerialNo; set => nSerialNo = value; }
        public int NBodyLen { get => nBodyLen; set => nBodyLen = value; }
        public byte[] ArrBodySHA1 { get => arrBodySHA1; set => arrBodySHA1 = value; }
        public byte[] ArrReserved { get => arrReserved; set => arrReserved = value; }
        public byte[] Bodys { get => bodys; set => bodys = value; }
    }

}
