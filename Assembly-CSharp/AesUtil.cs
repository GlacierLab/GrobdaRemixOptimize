using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

// Token: 0x020000D0 RID: 208
public class AesUtil
{
	// Token: 0x0600048A RID: 1162 RVA: 0x0000F4DA File Offset: 0x0000D8DA
	public static void Init()
	{
		AesUtil.tDESalg.Key = AesUtil.encoding.GetBytes("blacklenwhitelen");
		AesUtil.tDESalg.IV = AesUtil.encoding.GetBytes("typemoon");
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0000F510 File Offset: 0x0000D910
	public static void EncryptTextToFile(string Data, string FileName)
	{
		try
		{
			FileStream fileStream = File.Open(FileName, FileMode.OpenOrCreate);
			CryptoStream cryptoStream = new CryptoStream(fileStream, new TripleDESCryptoServiceProvider().CreateEncryptor(AesUtil.tDESalg.Key, AesUtil.tDESalg.IV), CryptoStreamMode.Write);
			StreamWriter streamWriter = new StreamWriter(cryptoStream);
			streamWriter.WriteLine(Data);
			streamWriter.Close();
			cryptoStream.Close();
			fileStream.Close();
		}
		catch (CryptographicException ex)
		{
			Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
		}
		catch (UnauthorizedAccessException ex2)
		{
			Console.WriteLine("A file access error occurred: {0}", ex2.Message);
		}
	}

	// Token: 0x0600048C RID: 1164 RVA: 0x0000F5BC File Offset: 0x0000D9BC
	public static string DecryptTextFromFile(string FileName)
	{
		string text2;
		try
		{
			FileStream fileStream = File.Open(FileName, FileMode.OpenOrCreate);
			CryptoStream cryptoStream = new CryptoStream(fileStream, new TripleDESCryptoServiceProvider().CreateDecryptor(AesUtil.tDESalg.Key, AesUtil.tDESalg.IV), CryptoStreamMode.Read);
			StreamReader streamReader = new StreamReader(cryptoStream);
			string text = streamReader.ReadToEnd();
			streamReader.Close();
			cryptoStream.Close();
			fileStream.Close();
			text2 = text;
		}
		catch (CryptographicException ex)
		{
			Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
			text2 = null;
		}
		catch (UnauthorizedAccessException ex2)
		{
			Console.WriteLine("A file access error occurred: {0}", ex2.Message);
			text2 = null;
		}
		return text2;
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0000F674 File Offset: 0x0000DA74
	public static byte[] EncryptTextToMemory(string Data)
	{
		byte[] array2;
		try
		{
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider().CreateEncryptor(AesUtil.tDESalg.Key, AesUtil.tDESalg.IV), CryptoStreamMode.Write);
			byte[] bytes = new ASCIIEncoding().GetBytes(Data);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.FlushFinalBlock();
			byte[] array = memoryStream.ToArray();
			cryptoStream.Close();
			memoryStream.Close();
			array2 = array;
		}
		catch (CryptographicException ex)
		{
			Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
			array2 = null;
		}
		return array2;
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0000F714 File Offset: 0x0000DB14
	public static string DecryptTextFromMemory(byte[] Data)
	{
		string text;
		try
		{
			MemoryStream memoryStream = new MemoryStream(Data);
			CryptoStream cryptoStream = new CryptoStream(memoryStream, new TripleDESCryptoServiceProvider().CreateDecryptor(AesUtil.tDESalg.Key, AesUtil.tDESalg.IV), CryptoStreamMode.Read);
			byte[] array = new byte[Data.Length];
			cryptoStream.Read(array, 0, array.Length);
			text = new ASCIIEncoding().GetString(array);
		}
		catch (CryptographicException ex)
		{
			Console.WriteLine("A Cryptographic error occurred: {0}", ex.Message);
			text = null;
		}
		return text;
	}

	// Token: 0x040002B5 RID: 693
	public static Encoding encoding = new UTF8Encoding();

	// Token: 0x040002B6 RID: 694
	public static TripleDESCryptoServiceProvider tDESalg = new TripleDESCryptoServiceProvider();
}
