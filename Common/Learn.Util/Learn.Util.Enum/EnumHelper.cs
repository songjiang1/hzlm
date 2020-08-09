using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace Learn.Util.Enum
{
    public class EnumHelper
    {
        public static List<EnumEntity> EnumToList<T>()
        {
            List<EnumEntity> list = new List<EnumEntity>();
            foreach (var e in System.Enum.GetValues(typeof(T)))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.desction = da.Description;
                }
                m.value = Convert.ToInt32(e);
                m.text = e.ToString();
                list.Add(m);
            }
            return list;
        }
        public static List<EnumEntity> EnumToList(Type type)
        {
            List<EnumEntity> list = new List<EnumEntity>();
            foreach (var e in System.Enum.GetValues(type))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.desction = da.Description;
                }
                m.value = Convert.ToInt32(e);
                m.text = e.ToString();
                list.Add(m);
            }
            return list;
        }
        public static List<EnumEntity> EnumStringToList(string enumName) 
        {
            string executingAssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            string mappingAssemblePath = Path.Combine(executingAssemblyDirectory, "Learn.Util.Enum.dll");

            if (!File.Exists(mappingAssemblePath))
                throw new Exception($"{mappingAssemblePath}文件不存在");

            Assembly asm = Assembly.LoadFile(mappingAssemblePath);
            Type [] types  = asm.GetTypes();
            foreach (var type in types)
            {
                if (type.Name.ToString().ToLower() == enumName.ToLower()) {
                    return EnumToList(type);
                }
            }
            return new List<EnumEntity>();
        }
       
        public static string GetDescription(System.Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = System.Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
    public class EnumEntity
    {
        public int value { get; set; }
        public string text { get; set; }
        public string desction { get; set; }
    }
}
