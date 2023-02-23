using System;
using System.Xml;
using UnityEngine;

// Token: 0x020000DA RID: 218
public class XmlUtil
{
	// Token: 0x060004BF RID: 1215 RVA: 0x00010084 File Offset: 0x0000E484
	protected XmlUtil()
	{
	}

	// Token: 0x060004C0 RID: 1216 RVA: 0x0001008C File Offset: 0x0000E48C
	public static float GetFloatFromNode(XmlNode node, string str, float d = 0f)
	{
		float num;
		try
		{
			string value = node.Attributes[str].Value;
			num = (float)XmlConvert.ToDouble(value);
		}
		catch (Exception)
		{
			num = d;
		}
		return num;
	}

	// Token: 0x060004C1 RID: 1217 RVA: 0x000100D4 File Offset: 0x0000E4D4
	public static int? GetIntNullFromNode(XmlNode node, string str)
	{
		int? num;
		try
		{
			string value = node.Attributes[str].Value;
			num = new int?(XmlConvert.ToInt32(value));
		}
		catch (Exception)
		{
			num = null;
		}
		return num;
	}

	// Token: 0x060004C2 RID: 1218 RVA: 0x00010128 File Offset: 0x0000E528
	public static int GetIntFromNode(XmlNode node, string str, int d = 100)
	{
		int num;
		try
		{
			string value = node.Attributes[str].Value;
			num = XmlConvert.ToInt32(value);
		}
		catch (Exception)
		{
			num = d;
		}
		return num;
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x0001016C File Offset: 0x0000E56C
	public static string GetStringFromNode(XmlNode node, string str)
	{
		string text;
		try
		{
			text = node.Attributes[str].Value;
		}
		catch (Exception)
		{
			text = null;
		}
		return text;
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x000101AC File Offset: 0x0000E5AC
	public static string GetStringFromNode(XmlNode node, string str, string d)
	{
		string text;
		try
		{
			text = node.Attributes[str].Value;
		}
		catch (Exception)
		{
			text = d;
		}
		return text;
	}

	// Token: 0x060004C5 RID: 1221 RVA: 0x000101EC File Offset: 0x0000E5EC
	public static bool GetBoolFromNode(XmlNode node, string name, bool d = false)
	{
		bool flag;
		try
		{
			flag = XmlConvert.ToBoolean(node.Attributes[name].Value);
		}
		catch (Exception)
		{
			flag = d;
		}
		return flag;
	}

	// Token: 0x060004C6 RID: 1222 RVA: 0x00010230 File Offset: 0x0000E630
	public static Color GetColorFromNode(XmlNode node, string r = "r", string g = "g", string b = "b", string a = "a")
	{
		return new Color
		{
			r = XmlUtil.GetFloatFromNode(node, r, 1f),
			g = XmlUtil.GetFloatFromNode(node, g, 1f),
			b = XmlUtil.GetFloatFromNode(node, b, 1f),
			a = XmlUtil.GetFloatFromNode(node, a, 1f)
		};
	}

	// Token: 0x060004C7 RID: 1223 RVA: 0x00010298 File Offset: 0x0000E698
	public static Vector3 GetVectorFromNode(XmlNode node, string x = "x", string y = "y", string z = "z")
	{
		return new Vector3
		{
			x = XmlUtil.GetFloatFromNode(node, x, 0f),
			y = XmlUtil.GetFloatFromNode(node, y, 0f),
			z = XmlUtil.GetFloatFromNode(node, z, 0f)
		};
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x000102E8 File Offset: 0x0000E6E8
	public static Vector3 GetScaleFromNode(XmlNode node, string x = "sx", string y = "sy", string z = "sz")
	{
		return new Vector3
		{
			x = XmlUtil.GetFloatFromNode(node, x, 1f),
			y = XmlUtil.GetFloatFromNode(node, y, 1f),
			z = XmlUtil.GetFloatFromNode(node, z, 1f)
		};
	}

	// Token: 0x060004C9 RID: 1225 RVA: 0x00010338 File Offset: 0x0000E738
	public static Vector3 GetRotatoFromNode(XmlNode node, string x = "rx", string y = "ry", string z = "rz")
	{
		return new Vector3
		{
			x = XmlUtil.GetFloatFromNode(node, x, 0f),
			y = XmlUtil.GetFloatFromNode(node, y, 0f),
			z = XmlUtil.GetFloatFromNode(node, z, 0f)
		};
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00010388 File Offset: 0x0000E788
	public static Color GetShaderColorFromNode(XmlNode node, string r = "sr", string g = "sg", string b = "sb", string a = "sa")
	{
		return new Color
		{
			r = XmlUtil.GetFloatFromNode(node, r, 1f),
			g = XmlUtil.GetFloatFromNode(node, g, 1f),
			b = XmlUtil.GetFloatFromNode(node, b, 1f),
			a = XmlUtil.GetFloatFromNode(node, a, 1f)
		};
	}
}
